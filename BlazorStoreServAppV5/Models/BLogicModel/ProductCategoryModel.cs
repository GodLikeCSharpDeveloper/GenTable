namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class ProductCategoryModel
    {
        public CategoryModel CategoryModel { get; set; }
        public int CategoryModelsId { get; set; }
        public ProductModel Product { get; set; }
        public int ProductModelsId { get; set; }
    }
}
