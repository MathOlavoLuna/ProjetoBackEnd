﻿using API_VidaPlus.Models;
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
        public DbSet<Exames> Exames { get; set; }   
        public DbSet<TiposExames> TiposExames { get; set; }
        public DbSet<Prontuarios> Prontuarios { get; set; }
        public DbSet<AgendaMedica> AgendaMedica { get; set; }
        public DbSet<Leitos> Leitos { get; set; }
        public DbSet<Hospital> Hospitais { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<RelatorioFinanceiroHospital> RelatoriosFinanceiros { get; set; }
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

            modelBuilder.Entity<Consultas>()
                .HasOne(c => c.Prescricao)
                .WithOne(p => p.PertenceConsulta)
                .HasForeignKey<Prescricoes>(p => p.ConsultaId);

            modelBuilder.Entity<Prescricoes>()
               .HasIndex(p => p.ConsultaId)
               .IsUnique();

            //Exames
            modelBuilder.Entity<Exames>()
                .HasOne(e  => e.Tipo)
                .WithMany(te => te.PertenceExames)
                .HasForeignKey(e => e.TipoExameId);

            modelBuilder.Entity<Exames>()
                .HasOne(e => e.Paciente)
                .WithMany(u => u.ExamesPaciente)
                .HasForeignKey(e => e.PacienteId);

            modelBuilder.Entity<Exames>()
                .HasOne(e => e.Medico)
                .WithMany(u => u.ExamesMedico)
                .HasForeignKey(e => e.MedicoId);

            //Prontuarios
            modelBuilder.Entity<Prontuarios>()
                .HasMany(p => p.ExamesPaciente)
                .WithOne(p => p.ParticipaProntuario)
                .HasForeignKey(e => e.ProntuarioId);

            modelBuilder.Entity<Prontuarios>() //diz que Prontuario vai ter muitas consultas, mas que uma consulta pertence a um prontuario.
                .HasMany(p => p.ConsultasPaciente)
                .WithOne(p => p.ParticipaProntuario)
                .HasForeignKey(c => c.ProntuarioId);

            modelBuilder.Entity<Prontuarios>()
                .HasOne(p => p.Paciente)
                .WithOne(p => p.ParticipaProntuario)
                .HasForeignKey<Prontuarios>(p => p.PacienteId);

            //Agenda Medica
            modelBuilder.Entity<AgendaMedica>()
                .HasOne(ag => ag.Medico)
                .WithOne(u => u.AgendaMedica)
                .HasForeignKey<AgendaMedica>(ag => ag.MedicoId);

            //Hospital
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Leitos)
                .WithOne(l => l.Hospital)
                .HasForeignKey(l => l.HospitalId);

            modelBuilder.Entity<Leitos>()
                .HasOne(l => l.Paciente)
                .WithOne(u => u.Internado)
                .HasForeignKey<Leitos>(l => l.PacienteId);

            modelBuilder.Entity<Hospital>()
                .HasOne(h => h.RelatorioFinanceiroHospital)
                .WithOne(rf => rf.Hospital)
                .HasForeignKey<Hospital>(rf => rf.RelatorioId);

            //RelatorioFinanceiro
            modelBuilder.Entity<RelatorioFinanceiroHospital>()
                .HasMany(rf => rf.Produtos)
                .WithOne(p => p.PertenceRelatorioHospital)
                .HasForeignKey(rf => rf.RelatorioId);


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
            