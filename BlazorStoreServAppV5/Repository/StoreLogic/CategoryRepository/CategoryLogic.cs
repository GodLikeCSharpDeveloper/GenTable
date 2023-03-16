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
            return await _storeContext.Categories.Include(x=>x.Tags).ToListAsync();
        }

        public async Task<bool> AddCategoryAsync(CategoryModel category)
        {
            await _storeContext.Categories.AddAsync(category);
            await _storeContext.SaveChangesAsync();
            return true;
        }

    }
}
