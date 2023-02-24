﻿using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorStoreServAppV5.Repository.StoreLogic.UserRepository
{
    public interface IUserRepositoryService
    {
        public async Task<List<Users>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByName(object obj)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByEmail(object obj)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersByPhone(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertUserAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(object obj)
        {
            throw new NotImplementedException();
        }
        public async Task<Users>? GetCurrentUser(Task<AuthenticationState> authenticationStateTask)
        {
            throw new NotImplementedException();
        }
    }
}
