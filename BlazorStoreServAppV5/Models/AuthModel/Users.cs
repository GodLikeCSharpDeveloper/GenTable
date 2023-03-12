using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Models.AuthModel
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public List<Roles> Roles { get; set; }
        public List<UserRoles>? UserRoles { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int CashbackCount { get; set; }
        public List<OrderModel> Orders { get; set; }
        public string? ImgSrcString { get; set; }
    }
}
