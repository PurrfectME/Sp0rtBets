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
    public class BasketballTeamMapping
    {
        public static BasketballTeam Map(BasketballTeamModel horse)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((BasketballTeamModel source) =>
                new BasketballTeam() {
                    Id = source.Id
                });

            var team1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<BasketballTeamModel, BasketballTeam>(result)
                .Map(new BasketballTeamModel() {
                    Id = horse.Id
                });

            return team1;
        }
    }
}