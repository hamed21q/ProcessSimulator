namespace MS.Domain.repository
{
    public class Process
    {
        public long Id { get; set; }
        public int Size { get; set; }
        public int Address { get; set; }
        public long SimulationId { get; set; }

        public virtual Simulation Simulation { get; set; }
        public Process(int capacity, long simId, int address)
        {
            Address = address;
            SimulationId = simId;
            Size = capacity;
        }
        public Process()
        {

        }
    }
}
