using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public class BaseScheduler : IScheduler
    {
        protected List<Process> processList;
        protected int counter;
        public BaseScheduler()
        {
            processList = new List<Process>();
            counter = 0;
        }

        public int TimeQuantom { get; set; }

        public void AddProcess(Process p)
        {
            processList.Add(p);
        }

        public void RemoveProcess(Process process)
        {
            processList.Remove(process);
        }

        public virtual List<ProcessViewModel> Schedule()
        {
            return null;
        }
        protected ProcessViewModel Convert(Process p)
        {
            return new ProcessViewModel
            {
                Id = p.Id,
                BurstTime = p.BurstTime,
                ArrivalTime = p.ArrivalTime,
                RemainingTime = p.remainingTime,
                Periority = p.Periority
            };
        }
    }
}
