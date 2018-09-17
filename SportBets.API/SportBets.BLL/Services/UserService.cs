using System;
using System.Collections.Generic;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;


namespace SportBets.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFinder _userFinder;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserFinder userFinder, IRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userFinder = userFinder;
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            user.RegistrationDate = DateTime.Now;
            var userToCreate = _userRepository.Create(user);
            _unitOfWork.Commit();

            return userToCreate;
        }

        public User DeleteUser(User user)
        {
            var userToDelete = _userRepository.Delete(user);
            _unitOfWork.Commit();

            return userToDelete;
        }

        public List<User> GetUserById(int id) => _userFinder.FindUserById(id);
      
        public List<User> GetUsersByRegDate(DateTime date) => _userFinder.FindUsersByRegDate(date);

        public List<User> GetAllUsers() => _userFinder.FindAllUsers();

    }
}
