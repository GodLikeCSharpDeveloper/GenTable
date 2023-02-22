using BlazorStoreServAppV5.Models.BLogicModel;


namespace BlazorStoreServAppV5.Repository.StoreLogic.OrderRepository
{
    public interface IOrderRepositoryServise
    {
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<OrderModel>> GetOrderByName(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertOrderAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
