using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.DTO
{
    class BetcardDTO
    {
        public DateTime BetDate { get; set; }
        public Bet BetId { get; set; }
    }
}
