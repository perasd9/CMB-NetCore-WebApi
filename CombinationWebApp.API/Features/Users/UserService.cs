using CombinationWebApp.API.Database.Interfaces.UnitOfWork;
using CombinationWebApp.API.Entities;

namespace CombinationWebApp.API.Features.Users
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll().ToList();
        }

        public async Task AddUser(User user)
        {
            _unitOfWork.UserRepository.Save(user);
            await _unitOfWork.SaveChanges();
        }
    }
}
