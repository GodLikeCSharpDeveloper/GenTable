namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductCategoryModel> ProductCategoriesModels { get; set; }
        public List<ProductModel> ProductModels { get; set; }

    }
}
