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
        public int Id { get; set; }
        public ItemType BetItemType { get; set; }
        public double Coefficient { get; set; }
        public DateTime BetDate { get; set; }
        public User UserId { get; set; }
    }
}
