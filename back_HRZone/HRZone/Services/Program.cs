using Buisnes;
using Data;
using Data.SqlClient;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración de las variables de entorno 
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = configuration["Configuracion:connectionString"];

// Cliente SQL
builder.Services.AddScoped<ClientSql>(provider =>
{
    // Construir e inicializar ClientSql con parámetros
    var clientSql = new ClientSql(connectionString);
    return clientSql;
});

builder.Services.AddScoped<authControllogical>();
builder.Services.AddScoped<UsersContrlollogical>();
builder.Services.AddScoped<DAOUsers>();
builder.Services.AddScoped<Users>();

builder.Services.AddScoped<HrzoneControllogical>();
builder.Services.AddScoped<DAOHrzone>();
builder.Services.AddScoped<HRzone>();

// Configuración de la autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddAuthorization();

// Agrega servicios para páginas Razor
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del middleware de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
