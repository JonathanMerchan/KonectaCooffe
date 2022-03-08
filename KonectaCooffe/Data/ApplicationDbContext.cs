using KonectaCooffe.Models;
using Microsoft.EntityFrameworkCore;

namespace KonectaCooffe.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<producto> Productos { get; set; }
        public DbSet<venta> Ventas { get; set; }
    }
}
