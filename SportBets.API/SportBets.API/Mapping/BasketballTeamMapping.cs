using EmitMapper;
using EmitMapper.MappingConfiguration;
using SportBets.API.Models;
using SportBets.BLL.Entities;

namespace SportBets.API.Mapping
{
    public class BasketballTeamMapping
    {
        public static BasketballTeam Map(BasketballTeamModel team)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((BasketballTeamModel source) =>
                new BasketballTeam() {
                    TeamName = source.TeamName,
                    WinsCount = source.WinsCount,
                    LossesCount = source.LossesCount
                });

            var team1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<BasketballTeamModel, BasketballTeam>(result)
                .Map(new BasketballTeamModel() {
                    TeamName = team.TeamName,
                    WinsCount = team.WinsCount,
                    LossesCount = team.LossesCount
                });

            return team1;
        }
    }
}