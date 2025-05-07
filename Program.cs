using API_VidaPlus.Data;
using API_VidaPlus.Services;
using API_VidaPlus.Services.Geral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    s => s.UseInlineDefinitionsForEnums()
    );
builder.Services.AddDbContext<DataContext>(opt =>
  opt.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection")!,
    new MySqlServerVersion(new Version(8, 0, 29))
  )
);
builder.Services.AddScoped(typeof(CRUDService<>));
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<ConsultasService>();
builder.Services.AddScoped<PrescricoesService>();
builder.Services.AddScoped<ExamesService>();
builder.Services.AddScoped<TiposExamesService>();

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
