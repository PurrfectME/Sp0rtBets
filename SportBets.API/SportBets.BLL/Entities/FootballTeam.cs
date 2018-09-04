namespace SportBets.BLL.Entities
{
    public class FootballTeam
    {
        public virtual int Id { get; set; }
        public virtual string TeamName { get; set; }
        public virtual int WinsCount { get; set; }
        public virtual int LossesCount { get; set; }

    }
}
