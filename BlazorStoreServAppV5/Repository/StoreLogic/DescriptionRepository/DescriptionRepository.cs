using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.StoreLogic.NewFolder
{
    public class DescriptionRepository : IDescriptionRepositoryService
    {
        private readonly StoreContext _storeContext;
        public DescriptionRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<List<DescriptionModel>> GetProductByDescription(DescriptionModel descr)
        {
            var products = await _storeContext.Descriptions.
                Where(a => 
                    a.Name.ToLower().Contains(descr.Name.ToLower()) || 
                    a.Description.ToLower().Contains(descr.Description.ToLower())).
                    ToListAsync();
            return products;
        }

        public async Task<bool> InsertDescriptionAsync(DescriptionModel descr)
        {
            await _storeContext.Descriptions.AddAsync(descr);
            await _storeContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateDescriptionAsync(DescriptionModel descr)
        {
            _storeContext.Descriptions.Update(descr);
            await _storeContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteDescriptionAsync(DescriptionModel descr)
        {
            _storeContext.Descriptions.Remove(descr);
            await _storeContext.SaveChangesAsync();
            return true;
        }
    }
}
