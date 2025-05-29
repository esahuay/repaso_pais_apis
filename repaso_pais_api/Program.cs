using Microsoft.EntityFrameworkCore;
using repaso_pais_api.BLL;
using repaso_pais_api.Models;
using repaso_pais_api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Creando conexion a base de datos
var configuration = builder.Configuration;
builder.Services.AddDbContext<paisContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregamos la transicion de servicios
builder.Services.AddTransient<ITablapaiService, TablapaiService>();

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
