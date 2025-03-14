using Ecommerce.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;initial Catalog=EcommerceCargoDb; User=sa; Password=Sertac1911u*;TrustServerCertificate= true;");
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
