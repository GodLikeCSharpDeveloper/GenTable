namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool InStock { get; set; }
        public bool IsCashback { get; set; } = false;
        public List<OrderModel>? OrderModels { get; set; } = new();
        public List<DescriptionModel>? DescriptionModels { get; set; } = new();
        public List<ProductOrderModel>? ProductsOrder { get; set; }
        public List<ProductCategoryModel>? ProductCategoryModels { get; set; }
        public List<CategoryModel>? CategoryModels { get; set; }
        public string? ImgSrcString { get; set; }
    }
}
