using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using WebApiLearning.Server.Configurations;
using WebApiLearning.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("game_items.json", optional: true, reloadOnChange: false);

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var mongoConfig = builder.Configuration.GetSection(nameof(MongoDbConfiguration)).Get<MongoDbConfiguration>();
    if (mongoConfig is null)
    {
        throw new InvalidOperationException("MongoDbConfiguration not found in configuration");
    }

    return new MongoClient(mongoConfig.ConnectionString);
});
builder.Services.AddSingleton<IGameItemsRepository, MongoDbRepository>();
builder.Services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();