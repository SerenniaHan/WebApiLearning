using Scalar.AspNetCore;
using WebApiLearning.Api.Endpoints;
using WebApiLearning.Core;
using WebApiLearning.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// builder.Services.AddInMemoryRepository();
builder.Services.AddWebApiLearningCore();
builder.Services.AddMongoDbRepository(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Hello GameStore!");

app.UseHttpsRedirection();
app.MapGameStoreEndpoints();

app.Run();