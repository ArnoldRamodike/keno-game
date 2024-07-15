using KenoGame.API;
using KenoGame.API.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GamesStoreContext>(connString);

var app = builder.Build();

app.MapGaesEndpoints();

app.MigrateDb();

app.Run();
