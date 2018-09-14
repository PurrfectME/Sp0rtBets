using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using SportBets.API.Models;
using SportBets.BLL.Entities;

namespace SportBets.API.Mapping
{
    public class UserMapping
    {
        public static void Map()
        {
            var config = new DefaultMapConfig();
            config.ConvertUsing((UserModel source) =>
                new User
                {
                    Email = source.Email,
                    Id = source.Id
                });

            var user = ObjectMapperManager
                .DefaultInstance
                .GetMapper<UserModel, User>(config)
                .Map()
                
        }

        
        
    }
}