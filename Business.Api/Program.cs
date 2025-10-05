using Business.Api;
using Business.Api.Data;
using Business.Api.Interfaces;
using Business.Api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Registrar EF Core con SQLite (podés cambiarlo a SQL Server si querés)
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite("Data Source=businessDB.db")
);

// ? Registrar el repositorio de Business para inyección de dependencias
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();

// ? Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ? Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
