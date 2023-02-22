using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Repository.StoreLogic.DescriptionRepository
{
    public interface IDescriptionRepositoryService
    {
        public async Task<List<DescriptionModel>> GetProductByDescription(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertDescriptionAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDescriptionAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDescriptionAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
