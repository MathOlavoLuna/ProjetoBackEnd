﻿// <auto-generated />
using System;
using API_VidaPlus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_VidaPlus.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250501175948_fix_consultas")]
    partial class fix_consultas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("API_VidaPlus.Models.Consultas", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Compareceu")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("MarcadoPara")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Prescricoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaId")
                        .IsUnique();

                    b.ToTable("Prescricoes");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Consultas", b =>
                {
                    b.HasOne("API_VidaPlus.Models.Usuarios", "Medico")
                        .WithMany("ConsultasMedico")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_VidaPlus.Models.Usuarios", "Paciente")
                        .WithMany("ConsultasPaciente")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Prescricoes", b =>
                {
                    b.HasOne("API_VidaPlus.Models.Consultas", "PertenceConsulta")
                        .WithOne("Prescricao")
                        .HasForeignKey("API_VidaPlus.Models.Prescricoes", "ConsultaId");

                    b.Navigation("PertenceConsulta");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Consultas", b =>
                {
                    b.Navigation("Prescricao");
                });

            modelBuilder.Entity("API_VidaPlus.Models.Usuarios", b =>
                {
                    b.Navigation("ConsultasMedico");

                    b.Navigation("ConsultasPaciente");
                });
#pragma warning restore 612, 618
        }
    }
}
