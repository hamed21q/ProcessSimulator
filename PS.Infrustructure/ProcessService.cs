using PS.Domain;
using PS.Domain.Application;

namespace PS.Infrustructure
{
    public class ProcessService
    {
        private readonly SimulatorContext context;
        private readonly CPU cpu;
        public ProcessService(SimulatorContext context, CPU cpu)
        {
            this.context = context;
            this.cpu = cpu;
        }
        public void Add(Process p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void Remove(Process p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public List<Process> GetAll()
        {
            return context.processes.ToList();
        }
        public Process getBy(long id)
        {
            return context.processes.Find(id);
        }

        public ProcessSimulationViewModel Simulate(string algo)
        {
            var command = new CreateProcessSimulationCommand
            {
                processes = Convert(GetAll()),
                Algorithm = algo
            };
            return cpu.Process(command);
        }
       public List<CreateProcessCommand> Convert(List<Process> processes)
        {
            var result = new List<CreateProcessCommand>();
            foreach (var process in processes)
            {
                result.Add(new CreateProcessCommand
                {
                    BurstTime = process.BurstTime,
                    ArrivalTime = process.ArrivalTime
                });
            }
            return result;
        }
    }
}
