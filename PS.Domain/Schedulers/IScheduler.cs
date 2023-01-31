using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public interface IScheduler
    {
        public int TimeQuantom { get; set; }
        List<ProcessViewModel> Schedule();
        void AddProcess(Process process);
        void RemoveProcess(Process process);
    }
}
