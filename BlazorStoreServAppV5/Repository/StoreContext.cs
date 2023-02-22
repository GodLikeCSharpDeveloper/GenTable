using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Models.BLogicModel;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderModel>()
                        .HasMany(s => s.Products)
                        .WithMany(c => c.OrderModels).
                        UsingEntity<ProductOrderModel>(
                            j => j
                                  .HasOne(pt => pt.ProductModel)
                                  .WithMany(t => t.ProductOrders)
                                  .HasForeignKey(pt => pt.OrderModelId),
                            j => j
                                  .HasOne(pt => pt.OrderModel)
                                  .WithMany(p => p.ProductOrders)
                                 .HasForeignKey(pt => pt.ProductModelId),
            j =>
            {
                j.HasKey(pt => new { pt.ProductModelId, pt.OrderModelId });
                j.ToTable("ProductsOrder");
            });
        }
    }


}

