using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.DTO
{
    class BetDTO
    {
        public ItemType BetItemType { get; set; }
        public double Coefficient { get; set; }
    }
}
