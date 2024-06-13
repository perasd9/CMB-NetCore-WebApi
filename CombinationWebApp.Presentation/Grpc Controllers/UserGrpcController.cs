using CombinationWebApp.Protos;
using Grpc.Core;

namespace CombinationWebApp.Presentation.Grpc_Controllers
{
    public class UserGrpcController : UserService.UserServiceBase
    {
        private readonly Application.Services.UserService _userService;

        public UserGrpcController(Application.Services.UserService userService)
        {
            _userService = userService;
        }

        public async override Task<UserList> GetAll(Empty request, ServerCallContext context)
        {
            try
            {
                List<CombinationWebApp.Core.Model.User> users = await _userService.GetUsers() ?? throw new RpcException(new Status(StatusCode.NotFound, "No users found"));
                List<User> grpcUsers = new();

                foreach (var user in users)
                {
                    grpcUsers.Add(new User
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Password = user.Password,
                        Name = user.Name,
                        Surname = user.Surname,
                        Address = user.Address
                    });
                }

                UserList userList = new();
                userList.Users.AddRange(grpcUsers);

                return userList;
            }
            catch (RpcException ex)
            {
                throw; // Re-throw RpcException
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Internal server error: {ex.Message}"));
            }
        }

        public override Task<UserList> GetBySearch(UserSearchRequest request, ServerCallContext context)
        {
            return base.GetBySearch(request, context);
        }

        public override Task<UserReply> Save(UserRequest request, ServerCallContext context)
        {
            return base.Save(request, context);
        }

        public override Task<UserReply> Update(UserRequest request, ServerCallContext context)
        {
            return base.Update(request, context);
        }

        public override Task<Empty> Remove(UserRemoveRequest request, ServerCallContext context)
        {
            return base.Remove(request, context);
        }
    }
}
