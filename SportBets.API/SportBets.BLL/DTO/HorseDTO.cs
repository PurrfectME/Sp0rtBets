using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.BLL.DTO
{
    class HorseDTO
    {
        public string HorseNmae { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public int WinsCount { get; set; }
        public int LossesCount { get; set; }
    }
}
