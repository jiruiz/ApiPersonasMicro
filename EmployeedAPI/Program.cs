using EmployeedAPI;
using EmployeedAPI.Data;
using EmployeedAPI.Interfaces;
using EmployeedAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar EF con SQLite
builder.Services.AddDbContext<DataContext>(
    options =>options.UseSqlite("Data Source=employeesDB.db")
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//cuando alguien pide un IEmployeeRepository, debe entregar un EmployeeRepository.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
