using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public interface IScheduler
    {
        public int TimeQuantom { get; set; }
        double AvrageTurnAroundTime();
        List<ProcessViewModel> Schedule();
        void AddProcess(Process process);
        void RemoveProcess(Process process);
        void SaveTurnAroundTime(Process p);
        List<ProcessStatistics> CalculateStatistics();
        void SaveWaitingTime(Process p);
        void SaveResponseTime(Process p);
    }
}
