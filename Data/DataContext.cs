using API_VidaPlus.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
            