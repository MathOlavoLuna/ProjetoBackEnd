using API_VidaPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Consultas> Consultas { get; set; }

        public DbSet<Prescricoes> Prescricoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Consultas
            modelBuilder.Entity<Consultas>()
                .HasOne(c => c.Paciente)
                .WithMany(u => u.ConsultasPaciente)
                .HasForeignKey(c => c.PacienteId);

            modelBuilder.Entity<Consultas>()
                .HasOne(c => c.Medico)
                .WithMany(u => u.ConsultasMedico)
                .HasForeignKey(c => c.MedicoId);
            

            // Define a unique constraint for the "Email" property
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Define a unique constraint for the "Cpf" property
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Cpf)
                .IsUnique();
        }
    }
}
            