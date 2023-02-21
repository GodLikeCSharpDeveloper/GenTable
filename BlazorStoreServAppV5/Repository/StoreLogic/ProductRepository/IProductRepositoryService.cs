using BlazorStoreServAppV5.Models.BLogicModel;
using GenericTableBlazorAppV4.Models;

namespace BlazorStoreServAppV5.Repository.StoreLogic.NewFolder2
{
    public interface IProductRepositoryService
    {
        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<ProductModel>> GetProductsByCategoryAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<ProductModel> GetOrderByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertProductAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
