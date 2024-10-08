using BCrypt.Net;
using KenoGame.API.Data;
using KenoGame.API.Dtos;
using KenoGame.API.Entities;
using KenoGame.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace KenoGame.API;

public static class UsersEndpoints
{
    const string GetUserEndpointName = "GetUser";
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app, JwtService jwtService)
    {
        var group = app.MapGroup("users")
            .WithParameterValidation();

        // Get Users
        group.MapGet("/", async (GamesStoreContext dbContext) =>
         await dbContext.Users
                // .Include(User => User.Role)
                .Select(user => user.ToUserSummuryDto())
                .AsNoTracking()
                .ToListAsync()
        ).RequireAuthorization();

        // Get User/id
        group.MapGet("/{id}", async (int id, GamesStoreContext dbContext) =>
        {
            User? user = await dbContext.Users.FindAsync(id);

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserDetailsDto());
        })
            .WithName(GetUserEndpointName)
            .RequireAuthorization();

        // Register
        group.MapPost("/register", async (CreateUserDto newUser, GamesStoreContext dbContext) =>
        {

            if (await dbContext.Users.AnyAsync(u => u.Email == newUser.Email))
            {
                return Results.BadRequest(new { error = "Invalid Email", Message = "Email already exists, please login" });
            }

            User user = newUser.ToEntity();
            user.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();


            return Results.CreatedAtRoute(GetUserEndpointName, new { id = user.Id }, user.ToUserDetailsDto());
        });
        // User Login
        group.MapPost("/login", async (LoginUserDto loginUser, GamesStoreContext dbContext) =>
        {

            var user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == loginUser.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                return Results.Unauthorized();
            }

            var token = jwtService.GenerateToken(user.Id);

            return Results.Ok(new { Token = token });
        });


        // Put User
        group.MapPut("/{id}", async (string id, UpdateUserDto updateUser, GamesStoreContext dbContext) =>
        {
            var existingUser = await dbContext.Users.FindAsync(id);

            if (existingUser is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingUser)
                    .CurrentValues
                    .SetValues(updateUser.ToUserUpdateDto(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        }).RequireAuthorization();

        // Delete User
        group.MapDelete("/{id}", async (GamesStoreContext dbContext, string id) =>
        {
            await dbContext.Users
                          .Where(user => user.Id == id)
                          .ExecuteDeleteAsync();

            return Results.NoContent();
        }).RequireAuthorization();

        return group;
    }

}
