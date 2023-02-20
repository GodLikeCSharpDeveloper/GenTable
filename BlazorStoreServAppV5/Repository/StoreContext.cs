using BlazorStoreServAppV5.Models.AuthModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository
{
    public class StoreContext : DbContext
    {
      
        public StoreContext(DbContextOptions<StoreContext> context) : base(context)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}

