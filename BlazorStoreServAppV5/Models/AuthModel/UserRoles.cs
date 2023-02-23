namespace BlazorStoreServAppV5.Models.AuthModel
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public Users? Users { get; set; }
        public int RoleId { get; set; }
        public Roles? Roles { get; set; }
    }
}
