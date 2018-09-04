namespace SportBets.BLL.Entities
{
    public class Horse
    {
        public virtual int Id { get; set; }
        public virtual string HorseName { get; set; }
        public virtual float Weight { get; set; }
        public virtual int Age { get; set; }
        public virtual int WinsCount { get; set; }
        public virtual int LossesCount { get; set; }
    }
}
