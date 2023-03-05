using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Repository.AccountLogic;
using BlazorStoreServAppV5.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorStoreServAppV5.Areas.Identity.Pages.Account;

public class LoginModel : PageModel
{

    private readonly IHttpContextAccessor _accessor;
    private readonly IAccountLogic _accountLogic;
    public LoginModel(IHttpContextAccessor accessor, IAccountLogic accountLogic)
    {
        _accessor = accessor;
        _accountLogic = accountLogic;
    }
    [BindProperty]
    public LoginVm LoginVm { get; set; }
    public string ErrorMessage;
    public async Task<IActionResult> OnGetAsync()
    {
        if (_accessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return Redirect("/");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ErrorMessage = await _accountLogic.UserLoginAsyn(LoginVm);
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            return Page();
        }

        return Redirect("/");
    }

}
