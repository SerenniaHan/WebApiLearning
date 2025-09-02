namespace WebApiLearning.Core.UseCases;

public interface ICommandAsync<in TRequest, TResponse> 
{
    Task<TResponse> HandleAsync(TRequest request);
}

public interface ICommandAsync<TResponse>
{
    Task<TResponse> HandleAsync();
}
