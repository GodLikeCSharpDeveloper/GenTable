using System.Security.Claims;
using BlazorStoreServAppV5.Models.AuthModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using BlazorStoreServAppV5.Repository;
using BlazorStoreServAppV5.Repository.AccountLogic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.AccountLogic 
{
    public class AccountLogic : IAccountLogic
    {
        private readonly StoreContext _storeContext;
        private readonly IHttpContextAccessor _accessor;

        public AccountLogic(StoreContext storeContext,
            IHttpContextAccessor accessor)
        {
            _storeContext = storeContext;
            _accessor = accessor;
        }

        
        private List<string> ResigstrationValidations(RegisterVm registerVm)
        {
            List<string> alerts = new();
            alerts.Clear();
            if (string.IsNullOrEmpty(registerVm.Email))
            {
                alerts.Add("Email can't be empty"); 
            }

            string emailRules = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            if (!Regex.IsMatch(registerVm.Email, emailRules))
            {
                alerts.Add("Not a valid email");
            }
            
            if (string.IsNullOrEmpty(registerVm.Password))
            {
                alerts.Add("Password password can't be empty");
            }
            if (string.IsNullOrEmpty(registerVm.ConfirmPassword))
            {
                alerts.Add("Confirm password can't be empty");
            }

            if (registerVm.Password != registerVm.ConfirmPassword)
            {
                alerts.Add("Invalid confirm password");
            }
            if (_storeContext.Users.Any(_ => _.Email.ToLower() == registerVm.Email.ToLower()))
            {
                alerts.Add("Email address is already in use");
            }
            

            // atleast one lower case letter
            // atleast one upper case letter
            // atleast one special character
            // atleast one number
            // atleast 8 character length
            string passwordRules = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            if(registerVm.Password!=null)
            if (!Regex.IsMatch(registerVm.Password, passwordRules))
            {
                alerts.Add("Must contain ...");
            }
            return alerts;
        }
        private string PasswordHash(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
        public async Task<(bool Success, List<string> Message)> UserRegistrationAsync(RegisterVm register)
        {
            List<string> message = ResigstrationValidations(register);
            if (message!=null)
            {
                return (false, message);
            }
             
            Users newUser = new();
            newUser.Email = register.Email;
            newUser.FirstName = register.FirstName;
            newUser.LastName = register.LastName;
            newUser.PasswordHash = PasswordHash(register.Password);

            _storeContext.Users.Add(newUser);
            await _storeContext.SaveChangesAsync();

            var role = await _storeContext.Roles.Where(_ => _.Name.ToUpper() == "USER")
                .FirstOrDefaultAsync();

            if (role != null)
            {
                UserRoles userRoles = new();
                userRoles.RoleId = role.Id;
                userRoles.UserId = newUser.Id;

                _storeContext.UserRoles.Add(userRoles);
                await _storeContext.SaveChangesAsync();
            }
            message.Clear();
            return (true, message);
        }
        private bool ValidatePasswordHash(string password, string dbPassword)
        {
            byte[] dbPasswordHashBytes = Convert.FromBase64String(dbPassword);

            byte[] salt = new byte[16];
            Array.Copy(dbPasswordHashBytes, 0, salt, 0, 16);

            var userPasswordBytes = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] userPasswordHash = userPasswordBytes.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (dbPasswordHashBytes[i + 16] != userPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<string> UserLoginAsyn(LoginVm loginVm)
        {
            Users? user = await _storeContext.Users.Where(_ => _.Email.ToLower() == loginVm.Email.ToLower()).FirstOrDefaultAsync();

            if (user == null)
            {
                return "Incorrect Login";
            }

            if (!ValidatePasswordHash(loginVm.Password, user.PasswordHash))
            {
                return "Incorrect Password";
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var userRoles = await _storeContext.UserRoles.Join(_storeContext.Roles,
                    ur => ur.RoleId,
                    u => u.Id,
                    (ur, u) => new { RoleId = ur.RoleId, RoleName = u.Name, UserId = ur.UserId }
                )
                .Where(_ => _.UserId == user.Id)
                .ToListAsync();

            foreach (var ur in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, ur.RoleName));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties{};

            await _accessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return string.Empty;
        }
    }
}
