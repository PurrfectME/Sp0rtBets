using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IUserFinder
    {
        List<User> FindUserById(User user);
        List<User> FindUsersByRegDate(User user);
        List<User> FindAllUsers();
    }
}
