namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class WrapperForOrders
    {
        public OrderModel orders;
        public bool OrderBool { get; set; }
        public WrapperForOrders(OrderModel orders)
        {
            this.orders = orders;
        }
    }
}
