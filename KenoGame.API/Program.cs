using KenoGame.API;
using KenoGame.API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGaesEndpoints();

app.Run();
