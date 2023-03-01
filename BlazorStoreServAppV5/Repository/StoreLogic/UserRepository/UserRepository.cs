using BlazorStoreServAppV5.Models.AuthModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.StoreLogic.UserRepository
{
    public class UserRepository : IUserRepositoryService
    {
        private readonly StoreContext _storeContext;

        public UserRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _storeContext.Users.Include(o => o.Orders).ThenInclude(o => o.Products).ToListAsync();
        }

        public async Task<List<Users>> GetUsersByName(Users user)
        {
            var users = await _storeContext.Users.Where(a =>
                                               a.FirstName.ToLower().Contains(user.FirstName) ||
                                               a.LastName.ToLower().Contains(user.LastName))
                                           .ToListAsync();
            return users;
        }

        public async Task<List<Users>> GetUsersByEmail(Users user)
        {
            var users = await _storeContext.Users.Where(a => a.Email.ToLower().Contains(user.Email)).ToListAsync();
            return users;
        }

        public async Task<List<Users>> GetUsersByPhone(Users user)
        {
            var users = await _storeContext.Users.Where(a => a.Phone.ToLower() == user.Phone).ToListAsync();
            return users;
        }

        public async Task<bool> InsertUserAsync(Users users)
        {
            await _storeContext.Users.AddAsync(users);
            await _storeContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(Users user)
        {
            try
            {
                _storeContext.Entry(user).State = EntityState.Modified;
                foreach (var order in user.Orders)
                {
                    if(order.Id!=0)
                    _storeContext.Entry(order).State = EntityState.Modified;
                    else
                    {
                        _storeContext.Entry(order).State = EntityState.Added;
                    }
                }
                var IdsofOrders = user.Orders.Select(x=>x.Id).ToList();
                var orderToDelete = await _storeContext.Orders.Where(x => !IdsofOrders.Contains(x.Id)&& x.UserId == user.Id).ToListAsync();
                _storeContext.RemoveRange(orderToDelete);
                await _storeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(Users users)
        {
            _storeContext.Users.Remove(users);
            await _storeContext.SaveChangesAsync();
            return true;
        }
        public async Task<Users>? GetCurrentUser(Task<AuthenticationState> authenticationStateTask)
        {
            var List = await _storeContext.Users.Include(o => o.Orders).ThenInclude(o => o.Products).ToListAsync();
            var authState = await authenticationStateTask;
            var user = authState.User;
            var currentUser = List.Where(o => (o.FirstName + " " + o.LastName).Equals(user.Identity.Name)).FirstOrDefault();
            return currentUser;
        }

    }
}