using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;
using WebApiLearning.Infrastructure.Mongo.Repositories;

namespace WebApiLearning.Infrastructure.Mongo;

public static class Extensions
{
    public static IServiceCollection UseMongoRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));
        BsonSerializer.RegisterSerializer(
            new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String)
        );

        services.AddSingleton<IMongoClient>(_ => new MongoClient(
            configuration["MongoDbSettings:ConnectionString"]
                ?? throw new Exception("MongoDB connection string is not configured.")
        ));

        services.AddSingleton(services =>
        {
            var client = services.GetRequiredService<IMongoClient>();
            return client.GetDatabase(
                configuration["MongoDbSettings:DatabaseName"]
                    ?? throw new Exception("MongoDB database name is not configured.")
            );
        });

        services.AddSingleton<IGameItemRepository<Weapon>, WeaponsRepository>();
        services.AddSingleton<IShopRepository, ShopRepository>();
        services.AddSingleton<IInventoryRepository, InventoriesRepository>();
        return services;
    }
}
