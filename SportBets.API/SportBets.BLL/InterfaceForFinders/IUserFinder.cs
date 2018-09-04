using System;
using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IUserFinder
    {
        List<User> FindUserById(int id);
        List<User> FindUsersByRegDate(DateTime registrationDate);
        List<User> FindAllUsers();
    }
}
