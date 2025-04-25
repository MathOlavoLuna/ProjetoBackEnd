using API_VidaPlus.Data;
using API_VidaPlus.Services;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
  opt.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection")!,
    new MySqlServerVersion(new Version(8, 0, 29))
  )
);
builder.Services.AddScoped(typeof(CRUDService<>));
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<ConsultasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
