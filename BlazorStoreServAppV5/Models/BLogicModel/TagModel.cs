namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class TagModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public List<CategoryModel>? Categories { get; set; }
        public List<TagCategoryModel>? TagCategoryModels { get; set; }
    }
}
