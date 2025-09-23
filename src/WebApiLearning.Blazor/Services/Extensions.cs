namespace WebApiLearning.Blazor.Services;

public static class Extensions
{
    public static IHttpClientBuilder AddShopService(this IServiceCollection services)
    {
        return services.AddHttpClient<ShopService>(
            (serviceProvider, client) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(
                    configuration.GetConnectionString("ApiServerUrl")
                        ?? throw new InvalidOperationException(
                            "Connection string 'ApiServerUrl' not found."
                        )
                );
            }
        );
    }

    public static IHttpClientBuilder AddInventoryService(this IServiceCollection services)
    {
        return services.AddHttpClient<InventoryService>(
            (serviceProvider, client) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(
                    configuration.GetConnectionString("ApiServerUrl")
                        ?? throw new InvalidOperationException(
                            "Connection string 'ApiServerUrl' not found."
                        )
                );
            }
        );
    }

    public static IHttpClientBuilder AddWeaponService(this IServiceCollection services)
    {
        return services.AddHttpClient<WeaponService>(
            (serviceProvider, client) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(
                    configuration.GetConnectionString("ApiServerUrl")
                        ?? throw new InvalidOperationException(
                            "Connection string 'ApiServerUrl' not found."
                        )
                );
            }
        );
    }
}
