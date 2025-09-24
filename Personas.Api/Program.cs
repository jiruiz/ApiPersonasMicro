//----
// Program.cs: arranque de la API. Configura controladores y Swagger (OpenAPI).
using Microsoft.OpenApi.Models;
using Personas.Api.Data;
using Personas.Api.Repositories;
//------------------------------------------------- 



var builder = WebApplication.CreateBuilder(args);



// Configuración Mongo desde appsettings.json
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<MongoContext>();

//  REGISTRO DEL REPOSITORIO
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Personas API",
        Version = "v1",
        Description = "Microservicio simple: Nombre y Apellido"
    });
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
// Enrutar controllers
app.MapControllers();

app.Run();
