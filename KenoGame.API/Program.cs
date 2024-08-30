using KenoGame.API;
using KenoGame.API.Data;
using KenoGame.API.Endpoints;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GamesStoreContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// var connString = builder.Configuration.GetConnectionString("GameStore");
// builder.Services.AddSqlite<GamesStoreContext>(connString);

builder.Services.AddDataProtection();

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();
app.MapGet("/username", (HttpContext ctx, IDataProtectionProvider idp) =>
{
    var protector = idp.CreateProtector("auth-cookie");

    var authCookie = ctx.Response.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));

    var protectedPayload = authCookie.Split("=").Last();
    var payload = protector.Unprotect(protectedPayload);
    var parts = payload.Split(":");
    var key = parts[0];
    var value = parts[1];
    return value;
});

app.MapGet("/login", (HttpContext ctx, IDataProtectionProvider idp) =>
{
    var protector = idp.CreateProtector("auth-cookie");
    ctx.Response.Headers["set-cookie"] = $"auth={protector.Protect("user:arnold")}";
    return "ok";
});


await app.MigrateDbAsync();

app.Run();
