using Buisnes;
using Data;
using Entities; 
using Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using System;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//configuracion variables de entorno 
IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

string connectionString = configuration["Configuracion:connectionString"];
// cliente sql
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

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
