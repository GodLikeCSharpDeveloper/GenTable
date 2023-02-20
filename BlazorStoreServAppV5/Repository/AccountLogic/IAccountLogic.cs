using BlazorStoreServAppV5.Models.AuthModel;

namespace BlazorStoreServAppV5.Repository.AccountLogic
{
    public interface IAccountLogic
    {
        Task<(bool Success, string Message)> UserRegistrationAsync(RegisterVm register);
        Task<string> UserLoginAsyn(LoginVm loginVm);

    }
}
