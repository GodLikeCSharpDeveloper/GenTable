using GenericTableBlazorAppV4.Models;

namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class DescriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
