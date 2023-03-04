using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Repository.StoreLogic.CategoryRepository
{
    public interface ICategoryLogic
    {
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AddCategoryAsync(CategoryModel category)
        {
            throw new NotImplementedException();
        }
    }
}
