using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Repository.AccountLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorStoreServAppV5.Areas.Identity.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAccountLogic _accountLogic;
    public RegisterModel(IHttpContextAccessor httpContextAccessor,
        IAccountLogic accountLogic)
    {
        _httpContextAccessor = httpContextAccessor;
        _accountLogic = accountLogic;
    }

    [BindProperty]
    public RegisterVm RegisterForm { get; set; }

    public List<string> ErrorMessage { get; set; }

    public bool IsUserRegistrationSuccessfull { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return Redirect("/");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var registration = await _accountLogic.UserRegistrationAsync(RegisterForm);
        if (!registration.Success)
        {
            ErrorMessage = registration.Message;
        }
        else
        {
            IsUserRegistrationSuccessfull = true;
        }
        return Page();
    }
}
