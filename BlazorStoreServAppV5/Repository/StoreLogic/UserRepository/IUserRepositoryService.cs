using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorStoreServAppV5.Repository.StoreLogic.UserRepository
{
    public interface IUserRepositoryService
    {
        public async Task<List<Users>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByName(Users user)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByEmail(Users user)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByPhone(Users user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertUserAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(Users users)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(Users user)
        {
            throw new NotImplementedException();
        }
        public async Task<Users>? GetCurrentUser(Task<AuthenticationState> authenticationStateTask)
        {
            throw new NotImplementedException();
        }
    }
}

