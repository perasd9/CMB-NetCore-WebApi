using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;
using CombinationWebApp.Protos;
using Grpc.Core;

namespace CombinationWebApp.Application.GrpcServices
{
    public class UserServiceGrpc : UserService.UserServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServiceGrpc(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            List<CombinationWebApp.Core.Model.User> users = _unitOfWork.UserRepository.GetAll().ToList();

            List<User> grpcUsers = new List<User>();

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

            UserList userList = new UserList();
            userList.Users.AddRange(grpcUsers);

            return grpcUsers;
        }
    }
}
