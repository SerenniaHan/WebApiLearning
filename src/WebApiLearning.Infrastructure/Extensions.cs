using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using WebApiLearning.Core.Repository;
using WebApiLearning.Infrastructure.Repositories;

namespace WebApiLearning.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInMemoryRepository(this IServiceCollection services)
    {
        return services.AddSingleton<IGameStoreRepository, InMemoryRepository>();
    }

    public static IServiceCollection AddMongoDbRepository(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));

        services.AddSingleton<IMongoClient>(_ =>
        {
            return new MongoClient("mongodb://localhost:27017");
        });

        services.AddSingleton<IGameStoreRepository, MongoDbRepository>();

        return services;
    }
}