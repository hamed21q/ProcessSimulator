namespace PS.Domain.Application
{
    public class ProcessStatistics
    {
        public long id { get; set; }
        public int TurnAroundTime { get; set; }
        public int WaitingTime { get; set; }
        public int ResponseTime { get; set; }
    }
}
