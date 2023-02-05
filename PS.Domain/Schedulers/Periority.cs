using PS.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Schedulers
{
    public class Periority : BaseScheduler, IScheduler
    {
        public override List<ProcessViewModel> Schedule()
        {
            var list = new List<ProcessViewModel>();
            while (true)
            {
                var p = getMostValuable();
                if (p == null) break;
                for (int i = 0; i < TimeQuantom; i++)
                {
                    p.Excute();
                    list.Add(Convert(p));
                    counter++;
                }
            }
            return list;
        }
        private Process getMostValuable()
        {
            return processList.Where(p => p.ArrivalTime <= counter).MinBy(p => p.Periority);
        }
    }
}
