using System.Collections.Generic;
using System.Linq;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    public interface IUserService
    {
        User CreateUser(User user);
        User DeleteUser(User user);
        List<User> GetUserById(User user);
        List<User> GetUsersByRegDate(User user);
        List<User> GetAllUsers();
    }
}
