using DECommerce.Models;
using DECommers.Models;
using Microsoft.EntityFrameworkCore;

namespace DECommerce.Repository
{
    public class DECommerceDb : DbContext
    {
        private string _connectionString;

        public DECommerceDb(DbContextOptions<DECommerceDb> options) : base(options)
        {
        }
        public DECommerceDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasOne(x => x.Users).
                 WithMany(x => x.UserRole).HasForeignKey(x => x.UserID);

            modelBuilder.Entity<UserRole>().HasOne(x => x.Roles).
                 WithMany(x => x.UserRole).HasForeignKey(x => x.RoleID);

            modelBuilder.Entity<Products>().HasMany(x => x.OrderDetails).
                 WithOne(x => x.Products).HasForeignKey(x => x.OrderDetailsID);

            modelBuilder.Entity<Products>().HasOne(x => x.ProductCategories).
                 WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoriesID);

            modelBuilder.Entity<Orders>().HasMany(x => x.OrderDetails).
                 WithOne(x => x.Orders).HasForeignKey(x => x.OrderDetailsID);

            modelBuilder.Entity<Orders>().HasOne(x => x.Users).
                 WithMany(x => x.Orders).HasForeignKey(x => x.UserID);

        }



    }
}