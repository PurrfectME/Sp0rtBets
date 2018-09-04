using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class UserFinder : BaseFinder<User> , IUserFinder
    {
        public UserFinder(DbSet<User> entities) : base(entities)
        {
        }
        
        public List<User> FindUserById(int id)
        {
            var userById = Find().Where(x => x.Id.Equals(id)).ToList();

            return userById;
        }

        public List<User> FindUsersByRegDate(DateTime dateTime)
        {
            var usersByRegDate = Find().Where(x => x.RegistrationDate.Equals(dateTime)).OrderBy(x => x.Id)
                .ToList();

            return usersByRegDate;
        }

        public List<User> FindAllUsers()
        {
            var allUsers = Find().ToList();

            return allUsers;
        }
    }
}
