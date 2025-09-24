// Program.cs: arranque de Clientes API, Swagger y HttpClient para llamar a Personas.Api.
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Swagger (contrato de Clientes API)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clientes API",
        Version = "v1",
        Description = "Microservicio que consume Personas API"
    });
});

// Registramos HttpClient con BaseAddress hacia Personas.Api (puerto 5080)
builder.Services.AddHttpClient("personas", client =>
{
    client.BaseAddress = new Uri("http://localhost:5080/");
});



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
