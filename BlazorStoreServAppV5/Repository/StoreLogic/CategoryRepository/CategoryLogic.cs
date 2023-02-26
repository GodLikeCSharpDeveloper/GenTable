using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.StoreLogic.CategoryRepository
{
    public class CategoryLogic :ICategoryLogic
    {
        private readonly StoreContext _storeContext;

        public CategoryLogic(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _storeContext.Categories.ToListAsync();
        }
    }
}
