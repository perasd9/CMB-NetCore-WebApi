using Carter;

namespace CombinationWebApp.API.Features.Users.GetUsers
{
    public class GetUsersEndpoint : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/v1/user", async (UserService userService) =>
            {
                var users = await userService.GetUsers();

                return Results.Ok(users);
            });
        }
    }
}
