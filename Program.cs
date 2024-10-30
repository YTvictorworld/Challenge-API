using Challenge.Full.Stack.WebDev.Models;
using Challenge.Full.Stack.WebDev.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Swashbuckle.AspNetCore.Swagger;
using Challenge.Full.Stack.WebDev.Controllers;

var builder = WebApplication.CreateBuilder(args);

var dbHost = "localhost";
var dbName = "your_database_name";
var dbPass = "your_password";

var connStr = $"server={dbHost}; port=3306; database={dbName}; user=root; password={dbPass}";

// Configura los servicios antes de construir la aplicación
builder.Services.AddDbContext<ProductDbContext>(options => 
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Todo API", Version = "v1" });
});

var app = builder.Build();

// Configura Swagger y Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

//Mapea los controladores de la API
app.MapControllers();

// Define las rutas
app.MapGet("/", () => "Hello World! Yes");

app.Run();
