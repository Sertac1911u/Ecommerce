using Ecommerce.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1436;initial Catalog=EcommerceCommentDb; User=sa; Password=Sertac1911s*;TrustServerCertificate= true;");
        }
        public DbSet<UserComment> UserComments  { get; set; }
    }
}
