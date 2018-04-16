using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RESTauranterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTauranterContext(DbContextOptions<RESTauranterContext> options) : base(options) { }

         public DbSet<Review> Reviews { get; set; }
    }
}