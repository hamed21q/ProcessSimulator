using PS.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Schedulers
{
    public class SRT : BaseScheduler, IScheduler
    {
        public override List<ProcessViewModel> Schedule()
        {
            var list = new List<ProcessViewModel>();
            while (true)
            {
                var p = GetSmallest();
                if (p == null) break;
                p.Excute();
                list.Add(Convert(p));
                counter++;
            }
            return list;
        }
        private Process GetSmallest()
        {
            return processList.Where(p => p.ArrivalTime <= counter).MinBy(p => p.BurstTime);
        }
    }
}
