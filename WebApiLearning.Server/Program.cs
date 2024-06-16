using WebApiLearning.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("game_items.json", optional: true, reloadOnChange: false);
builder.Services.AddSingleton<IGameItemsRepository, JsonRepository>();
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