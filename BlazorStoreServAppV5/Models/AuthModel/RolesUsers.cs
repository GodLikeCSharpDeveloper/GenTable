using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Models.AuthModel
{
    public class RolesUsers
    {
        public int UsersId { get; set; }
        public Users? Users { get; set; }
        public int RolesId { get; set; }
        public Roles? Roles { get; set; }
    }
}
