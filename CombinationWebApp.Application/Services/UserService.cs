using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;
using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Application.Services
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
