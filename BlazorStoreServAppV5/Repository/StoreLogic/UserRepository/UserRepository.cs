using BlazorStoreServAppV5.Models.AuthModel;
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
            return await _storeContext.Users.ToListAsync();
        }
        public async Task<List<Users>> GetUsersByName(Users user)
        {
            var users = await _storeContext.Users.Where(a => a.FirstName.ToLower().Contains(user.FirstName) || a.LastName.ToLower().Contains(user.LastName)).ToListAsync();
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
        public async Task<bool> UpdateUserAsync(Users users)
        {
            _storeContext.Users.Update(users);
            await _storeContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserAsync(Users users)
        {
            _storeContext.Users.Remove(users);
            await _storeContext.SaveChangesAsync();
            return true;
        }

        public void GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}