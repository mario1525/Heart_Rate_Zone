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

// Configuraci�n de las variables de entorno 
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = configuration["Configuracion:connectionString"];

// Cliente SQL
builder.Services.AddScoped<ClientSql>(provider =>
{
    // Construir e inicializar ClientSql con par�metros
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

// Configuraci�n de la autenticaci�n JWT
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

// Agrega servicios para p�ginas Razor
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del middleware de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
