namespace BlazorStoreServAppV5.Models.AuthModel
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Users>? Users { get; set; }
        public List<UserRoles>? UserRoles { get; set; }
    }
}
