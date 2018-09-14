using System;

namespace SportBets.BLL.Entities
{
    public enum ItemType
    {
        Horse = 1,
        Football = 2,
        Basketball = 3
    }

    public class Bet
    {
        public virtual int Id { get; set; }
        public virtual ItemType BetItemType { get; set; }
        public virtual double Coefficient { get; set; }
        public virtual DateTime BetDate { get; set; }
        public virtual User User { get; set; }
    }
}
