using Carter;

namespace CombinationWebApp.API.Features.Users.CreateUser
{
    public class CreateUserEndpoint : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/user", async (UserService userService) =>
            {
                var users = await userService.GetUsers();

                return Results.Ok(users);
            });
        }
    }
}
