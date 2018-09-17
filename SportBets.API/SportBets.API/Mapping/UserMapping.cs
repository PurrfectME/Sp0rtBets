using EmitMapper;
using EmitMapper.MappingConfiguration;
using SportBets.API.Models;
using SportBets.BLL.Entities;

namespace SportBets.API.Mapping
{
    public class UserMapping
    {
        public static User Map(UserModel user)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((UserModel source) =>
                new User
                {
                    Email = source.Email
                });

            var user1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<UserModel, User>(result)
                .Map(new UserModel {
                    Email = user.Email
                });

            return user1;
        }
    }
}