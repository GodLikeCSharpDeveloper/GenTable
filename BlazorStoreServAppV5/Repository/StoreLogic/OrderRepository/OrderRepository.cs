using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.EntityFrameworkCore;


namespace BlazorStoreServAppV5.Repository.StoreLogic.OrderRepository
{
    public class OrderRepository : IOrderRepositoryServise
    {
        private readonly StoreContext _StoreContext;
        public OrderRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            return await _StoreContext.Orders.ToListAsync();
        }
        public async Task<List<OrderModel>> GetOrderByName(string user)
        {
            var order = await _StoreContext.Orders.Where(a => a.UserId.Equals(user)).ToListAsync();
            return order;
        }
        public async Task<OrderModel> InsertOrderAsync(OrderModel order)
        {
            await _StoreContext.Orders.AddAsync(order);
            await _StoreContext.SaveChangesAsync();
            return order;
        }
        public async Task<bool> UpdateOrderAsync(OrderModel order)
        {
            _StoreContext.Orders.Update(order);
            await _StoreContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrderAsync(OrderModel order)
        {
            _StoreContext.Orders.Remove(order);
            await _StoreContext.SaveChangesAsync();
            return true;
        }

    }
}



