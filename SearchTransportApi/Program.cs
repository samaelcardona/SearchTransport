using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SearchTransportApi.Business.Interfaces;
using SearchTransportApi.Business.Services;
using SearchTransportApi.DataAccess.Context;
using SearchTransportApi.DataAccess.Interfaces;
using SearchTransportApi.DataAccess.Repositories;
using SearchTransportApi.Models.ApiModels;

var builder = WebApplication.CreateBuilder(args);

// dependency inyection of connectionString
builder.Services.AddDbContext<SearchTransportContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:SearchTranportDB"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Browser Travel API", Version = "v1" });
    c.SchemaFilter<JsonRequestBodySchemaFilter<RequestVehicleByLocation>>();
});

//DI Configuration
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();


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
