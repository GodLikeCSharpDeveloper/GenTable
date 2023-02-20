using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Models.BLogicModel;
using GenericTableBlazorAppV4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository
{
    public class StoreContext : DbContext
    {
      
        public StoreContext(DbContextOptions<StoreContext> context) : base(context)
        {

        }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<DescriptionModel> Descriptions { get; set; }
    }
}

