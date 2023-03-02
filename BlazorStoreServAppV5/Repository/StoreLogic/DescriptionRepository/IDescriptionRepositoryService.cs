using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Repository.StoreLogic.DescriptionRepository
{
    public interface IDescriptionRepositoryService
    {
        public async Task<List<DescriptionModel>> GetProductByDescription(DescriptionModel descr)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertDescriptionAsync(DescriptionModel descr)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDescriptionAsync(DescriptionModel descr)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDescriptionAsync(DescriptionModel descr)
        {
            throw new NotImplementedException();
        }
    }
}
