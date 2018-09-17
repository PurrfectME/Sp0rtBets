using EmitMapper;
using EmitMapper.MappingConfiguration;
using SportBets.API.Models;
using SportBets.BLL.Entities;

namespace SportBets.API.Mapping
{
    public class BetMapping
    {
        public static Bet Map(BetModel bet)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((BetModel source) =>
                new Bet {
                    Coefficient = source.Coefficient,
                    BetItemType = source.BetType
                });

            var bet1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<BetModel, Bet>(result)
                .Map(new BetModel() {
                    Coefficient = bet.Coefficient,
                    BetType = bet.BetType
                });

            return bet1;
        }
    }
}