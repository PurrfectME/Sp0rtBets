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
    public class HorseMapping
    {
        public static Horse Map(HorseModel horse)
        {
            var config = new DefaultMapConfig();
            var result = config.ConvertUsing((HorseModel source) =>
                new Horse() {
                    HorseName = source.HorseName,
                    Weight = source.Weight,
                    Age = source.Age,
                    WinsCount = source.WinsCount,
                    LossesCount = source.LossesCount
                });

            var horse1 = ObjectMapperManager
                .DefaultInstance
                .GetMapper<HorseModel, Horse>(result)
                .Map(new HorseModel() {
                    HorseName = horse.HorseName,
                    Weight = horse.Weight,
                    Age = horse.Age,
                    WinsCount = horse.WinsCount,
                    LossesCount = horse.LossesCount
                    
                });

            return horse1;
        }
    }
}