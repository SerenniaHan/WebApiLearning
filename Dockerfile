FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebApiLearning.Api/WebApiLearning.Api.csproj", "src/WebApiLearning.Api/"]
COPY ["src/WebApiLearning.Application/WebApiLearning.Application.csproj", "src/WebApiLearning.Application/"]
COPY ["src/WebApiLearning.Domain/WebApiLearning.Domain.csproj", "src/WebApiLearning.Domain/"]
COPY ["src/WebApiLearning.Infrastructure.Mongo/WebApiLearning.Infrastructure.Mongo.csproj", "src/WebApiLearning.Infrastructure.Mongo/"]
RUN dotnet restore "src/WebApiLearning.Api/WebApiLearning.Api.csproj"
COPY . .
WORKDIR "/src/src/WebApiLearning.Api"
RUN dotnet build "./WebApiLearning.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApiLearning.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiLearning.Api.dll"]
