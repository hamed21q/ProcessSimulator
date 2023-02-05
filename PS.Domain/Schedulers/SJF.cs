    using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public class SJF : BaseScheduler, IScheduler
    {
        private int index;
        private Process p;
        public SJF() : base()
        {
            index = 0;
        }
        public override List<ProcessViewModel> Schedule()
        {
            var list = new List<ProcessViewModel>();
            while (true)
            {
                p = GetSmallest();
                if (p == null) break;
                p.Excute();
                list.Add(Convert(p));
                counter++;
            }
            return list;
        }
        private Process GetSmallest()
        {
            if (p != null
                && p.remainingTime > 0) 
            {
                return p;
            }
            return processList.Where(p => p.ArrivalTime <= counter).MinBy(p => p.BurstTime);
        }
    }
}
