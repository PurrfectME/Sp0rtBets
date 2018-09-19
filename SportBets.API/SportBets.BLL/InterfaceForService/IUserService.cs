using System;
using System.Collections.Generic;
using System.Linq;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    public interface IUserService
    {
        User CreateUser(User user);
        void DeleteUser(User user);
        List<User> GetUserById(int id);
        List<User> GetUsersByRegDate(DateTime date);
        List<User> GetAllUsers();
    }
}
