using System;

namespace SportBets.BLL.Entities
{
    public class Betcard
    {
        public int Id { get; set; }
        public DateTime BetDate { get; set; }
        public Bet BetId { get; set; }
    }
}
