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
        public List<UserRoles> UserRoles { get; set; }
    }
}
