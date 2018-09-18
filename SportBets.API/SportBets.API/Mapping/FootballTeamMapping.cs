using EmitMapper;
using EmitMapper.MappingConfiguration;
using SportBets.API.Models;
using SportBets.BLL.Entities;

namespace SportBets.API.Mapping
{
    public class FootballTeamMapping
    {
        public static FootballTeam Map(FootballTeamModel team)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((FootballTeamModel source) =>
                new FootballTeam() {
                    TeamName = source.TeamName,
                    WinsCount = source.WinsCount,
                    LossesCount = source.LossesCount
                });

            var team1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<FootballTeamModel, FootballTeam>(result)
                .Map(new FootballTeamModel() {
                    TeamName = team.TeamName,
                    WinsCount = team.WinsCount,
                    LossesCount = team.LossesCount
                });

            return team1;
        }
    }
}