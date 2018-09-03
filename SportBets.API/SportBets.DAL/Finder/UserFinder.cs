using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class UserFinder : BaseFinder<User> , IUserFinder
    {
        protected UserFinder(DbSet<User> entities) : base(entities)
        {
        }
        
        public List<User> FindUserById(User user)
        {
            var userById = Find().Where(x => x.Id.Equals(user.Id)).ToList();

            return userById;
        }

        public List<User> FindUsersByRegDate(User user)
        {
            var usersByRegDate = Find().Where(x => x.RegistrationDate.Equals(user.RegistrationDate)).OrderBy(x => x.Id)
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
