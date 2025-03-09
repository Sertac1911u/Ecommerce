using Ecommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Server=localhost,1434; initial Catalog=EcommerceOrderDb;User=sa;Password=Sertac1911u*;TrustServerCertificate= true;");
        }
        public DbSet<Address> Addresses {  get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
