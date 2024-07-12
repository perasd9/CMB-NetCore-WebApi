using CombinationWebApp.Protos;
using Google.Protobuf;
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

                var userListBytes = SerializeListToBytes(users);

                UserList userList = new()
                {
                    Users = ByteString.CopyFrom(userListBytes)
                };


                //byte[] userBytes = userList.Users.ToByteArray();
                //List<CombinationWebApp.Core.Model.User> usersMy;
                //using (var memoryStream = new MemoryStream(userBytes))
                //{
                //    usersMy = Serializer.Deserialize<List<CombinationWebApp.Core.Model.User>>(memoryStream);
                //}

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
        //helper method for serialization
        private byte[] SerializeListToBytes(List<CombinationWebApp.Core.Model.User> users)
        {
            using (var memoryStream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(memoryStream, users);
                return memoryStream.ToArray();
            }
        }

        public override Task<UserList> GetBySearch(UserSearchRequest request, ServerCallContext context)
        {
            return base.GetBySearch(request, context);
        }

        public async override Task<UserReply> Save(UserRequest request, ServerCallContext context)
        {
            Core.Model.User user = new()
            {
                Address = request.User.Address,
                Name = request.User.Name,
                Password = request.User.Password,
                Surname = request.User.Surname,
                Username = request.User.Username
            };

            await _userService.AddUser(user);

            return new UserReply() { User = request.User};
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
