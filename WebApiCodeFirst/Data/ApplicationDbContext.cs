using Microsoft.EntityFrameworkCore;
using WebApiCodeFirst.Models;

namespace WebApiCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor para las configuraciones
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //agregar las entidades
        public DbSet<Categoria> categoria { get; set; }
    }
}