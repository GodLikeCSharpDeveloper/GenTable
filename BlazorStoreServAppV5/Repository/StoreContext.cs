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
        public DbSet<ProductOrderModel> ProductsOrder { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductCategoryModel> ProductCategoryModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderModel>()
                        .HasMany(s => s.Products)
                        .WithMany(c => c.OrderModels).
                        UsingEntity<ProductOrderModel>(
                            j => j
                                  .HasOne(pt => pt.Product)
                                  .WithMany(t => t.ProductsOrder)
                                  .HasForeignKey(pt => pt.ProductModelId),
                            j => j
                                  .HasOne(pt => pt.OrderModel)
                                  .WithMany(p => p.ProductsOrder)
                                 .HasForeignKey(pt => pt.OrderModelId),
            j =>
            {
                j.HasKey(pt => new { pt.ProductModelId, pt.OrderModelId });
                    j.ToTable("Test");
            });
            modelBuilder.Entity<Users>()
                        .HasMany(s => s.Roles)
                        .WithMany(c => c.Users).
                        UsingEntity<UserRoles>(
                            j => j
                                 .HasOne(pt => pt.Roles)
                                 .WithMany(o => o.UserRoles)
                                 .HasForeignKey(pt => pt.RoleId),
                            j => j
                                 .HasOne(pt => pt.Users)
                                 .WithMany(p => p.UserRoles)
                                 .HasForeignKey(pt => pt.UserId),
                            j =>
                            {
                                j.HasKey(pt => new { pt.UserId, pt.RoleId });
                            });
            modelBuilder.Entity<ProductModel>()
                .HasMany(s => s.CategoryModels)
                .WithMany(c => c.ProductModels).
                UsingEntity<ProductCategoryModel>(
                    j => j
                        .HasOne(pt => pt.CategoryModel)
                        .WithMany(o => o.ProductCategoriesModels)
                        .HasForeignKey(pt => pt.CategoryModelsId),
                    j => j
                        .HasOne(pt => pt.Product)
                        .WithMany(p => p.ProductCategoryModels)
                        .HasForeignKey(pt => pt.ProductModelsId),
                    j =>
                    {
                        j.HasKey(pt => new { pt.CategoryModelsId, pt.ProductModelsId });
                    });

        }
    }


}

