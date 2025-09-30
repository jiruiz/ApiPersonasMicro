using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Negocios.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Negocios API",
        Version = "v1",
        Description = "Microservicio que Negocios API"
    });
});

// Registramos HttpClient con BaseAddress hacia Personas.Api (puerto 5080)
builder.Services.AddHttpClient("negocios", client =>
{
    client.BaseAddress = new Uri("http://localhost:5082/");
});


builder.Services.AddDbContext<NegociosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
