namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public bool IsCashback { get; set; } = false;
        public List<OrderModel>? OrderModels { get; set; } = new();
        public List<DescriptionModel>? DescriptionModels { get; set; } = new();
        public List<ProductOrderModel>? ProductOrders { get; set; }
    }
}
