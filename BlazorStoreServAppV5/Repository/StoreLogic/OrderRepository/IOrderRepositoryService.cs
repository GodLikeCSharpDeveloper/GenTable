using BlazorStoreServAppV5.Models.BLogicModel;


namespace BlazorStoreServAppV5.Repository.StoreLogic.OrderRepository
{
    public interface IOrderRepositoryServise
    {
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<OrderModel>> GetOrderByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> InsertOrderAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
