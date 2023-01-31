using PS.Domain.Schedulers;

namespace PS.Domain
{
    public class SchedulerFactory
    {
        public IScheduler GetScheduler(string name)
        {
            switch (name)
            {
                case "RN":
                    return new RoundRobin();
                case "FCFS":
                    return new FCFS();
                case "SJF": 
                    return new SJF();
                case "SRT":
                    return new SRT();
                case "PR":
                    return new Periority();
                case "MLQ":
                    return new MLQ();
                default: throw new ArgumentException();
            }
        }
    }
}
