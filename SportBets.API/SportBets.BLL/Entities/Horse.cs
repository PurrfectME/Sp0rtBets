namespace SportBets.BLL.Entities
{
    public class Horse
    {
        public int Id { get; set; }
        public string HorseName { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public int WinsCount { get; set; }
        public int LossesCount { get; set; }
    }
}
