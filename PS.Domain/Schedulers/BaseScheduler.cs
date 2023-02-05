using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public class BaseScheduler : IScheduler
    {
        protected List<Process> processList;
        private List<Process> cloneList;
        protected int counter;
        public BaseScheduler()
        {
            processList = new List<Process>();
            cloneList = new List<Process>();
            counter = 0;
        }

        public int TimeQuantom { get; set; }

        public double AvrageTurnAroundTime()
        {
            int sum = 0;
            cloneList.ForEach(p => sum += p.TurnAroundTime);
            return sum / processList.Count;
        }

        public virtual void AddProcess(Process p)
        {
            processList.Add(p);
            cloneList.Add(p);
        }

        public void RemoveProcess(Process process)
        {
            processList.Remove(process);
        }

        public void SaveTurnAroundTime(Process p)
        {
            p.TurnAroundTime = counter + 1;
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

        public List<ProcessStatistics> CalculateStatistics()
        {
            var list = new List<ProcessStatistics>();
            foreach (var p in cloneList)
            {
                var st = new ProcessStatistics
                {
                    id = p.Id,
                    TurnAroundTime = p.TurnAroundTime,
                    WaitingTime = p.WaitingTime,
                    ResponseTime = p.ResponseTime
                };
                list.Add(st);
            }
            return list;
        }

        public void SaveWaitingTime(Process p)
        {
            p.WaitingTime = counter - (p.BurstTime - 1);
        }

        public void SaveResponseTime(Process p)
        {
            p.ResponseTime = counter;
        }
    }
}
