using KenoGame.API;
using KenoGame.API.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GamesStoreContext>(connString);

var app = builder.Build();

app.MapGaesEndpoints();

app.Run();
