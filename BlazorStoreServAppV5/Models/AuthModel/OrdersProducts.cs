using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Models.AuthModel
{
    public class OrdersProducts
    {
        public int UsersId { get; set; }
        public Users? Users { get; set; }
        public int ProductsId { get; set;}
        public ProductModel? ProductModel { get; set;}
    }
}
