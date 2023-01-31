using PS.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Schedulers
{
    public class FCFS : BaseScheduler, IScheduler
    {
        private int index;
        public FCFS() : base()
        {
            index = 0;
        }

        public override List<ProcessViewModel> Schedule()
        {
            sort();
            var list = new List<ProcessViewModel>();
            while(index < processList.Count)
            {
                if (processList[index].Finished())
                {
                    index++;
                    if (index >= processList.Count)
                        break;
                }
                Process p = processList[index];
                list.Add(Convert(p));
                p.Excute();
                counter++;
            }
            return list;
        }
        private void sort()
        {
            processList =  processList.OrderBy(p => p.ArrivalTime).ToList();
        }

    }
}
