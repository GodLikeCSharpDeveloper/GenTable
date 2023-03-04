using BlazorStoreServAppV5.Models.BLogicModel;


namespace BlazorStoreServAppV5.Repository.StoreLogic.ProductRepository
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

        public async Task<bool> InsertProductAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetProductByOrder()
        {
            throw new NotImplementedException();
        }
    }
}
