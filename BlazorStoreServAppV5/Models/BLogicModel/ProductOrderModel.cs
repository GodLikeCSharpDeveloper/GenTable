namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public ProductModel? ProductModel { get; set; }
        public int ProductModelId { get; set; }
        public OrderModel? OrderModel { get; set; }
        public int OrderModelId { get; set; }
    }
}
