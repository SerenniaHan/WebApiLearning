using System.Text.Json;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using WebApiLearning.Api.Endpoints;
using WebApiLearning.Application;
using WebApiLearning.Infrastructure.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.UseMongoRepositories(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false)
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Hello GameStore!");

app.UseHttpsRedirection();

app.MapWeaponEndpoints();
app.MapShopEndpoints();
app.MapInventoryEndpoints();

app.Run();
