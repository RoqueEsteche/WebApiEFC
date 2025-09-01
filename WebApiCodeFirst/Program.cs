using Microsoft.EntityFrameworkCore;
using WebApiCodeFirst.Data;
using WebApiCodeFirst.Mappers;
using WebApiCodeFirst.Repositorios;
using WebApiCodeFirst.Repositorios.IRepositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Agregar la conexion a la base de datos al container
builder.Services.AddDbContext<ApplicationDbContext>(
    opciones => opciones.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionSql")
    )
);

//Agregar los repositorios al container
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

//Agregar el AutoMapper
builder.Services.AddAutoMapper(typeof(ApiMapper));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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