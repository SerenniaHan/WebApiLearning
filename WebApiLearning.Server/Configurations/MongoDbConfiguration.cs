namespace WebApiLearning.Server.Configurations;

public class MongoDbConfiguration
{
    public string? Host { get; set; }
    public int Port { get; set; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}