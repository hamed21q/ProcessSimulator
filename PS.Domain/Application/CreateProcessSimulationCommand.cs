namespace PS.Domain.Application
{
    public class CreateProcessSimulationCommand
    {
        public List<CreateProcessCommand> processes { get; set; }
        public string Algorithm { get; set; }
        public int TimeQuantom { get; set; } = 1;
    }
    public class CreateProcessCommand
    {
        public int BurstTime { get; set; }
        public int ArrivalTime { get; set; }
        public int Periority { get; set; } = 1;
    }
}
