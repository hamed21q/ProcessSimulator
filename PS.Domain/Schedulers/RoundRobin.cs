using PS.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Schedulers
{
    public class RoundRobin : BaseScheduler
    {

        private int index;
        public RoundRobin() : base()
        {
            index = 0;
        }
        public override List<ProcessViewModel> Schedule()
        {
            List<ProcessViewModel> list = new List<ProcessViewModel>();
            while (true)
            {
                Process p = processList[index];
                if(p.ArrivalTime > counter) 
                {
                    IncrementIndex(); 
                    p = processList[index]; 
                }
                if (!p.Finished())
                {
                    for (int i = 0; i < this.TimeQuantom; i++)
                    {
                        p.Excute();
                        list.Add(Convert(p));
                        counter++;
                        if (p.Finished()) { index--; break; }
                    }
                }
                if(processList.Count == 0) { break; }
                IncrementIndex();
            }
            return list;
        }
        private void IncrementIndex()
        {
            index = index == processList.Count - 1 ? 0 : index + 1;
        }
    }    
}