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
    public class FootballTeamMapping
    {
        public static FootballTeam Map(FootballTeamModel horse)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((FootballTeamModel source) =>
                new FootballTeam() {
                    Id = source.Id
                });

            var team1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<FootballTeamModel, FootballTeam>(result)
                .Map(new FootballTeamModel() {
                    Id = horse.Id
                });

            return team1;
        }
    }
}