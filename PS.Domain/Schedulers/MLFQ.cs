using PS.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Schedulers
{
    public class MLFQ : BaseScheduler, IScheduler
    {
        private readonly List<Queue<Process>> levels;
        private readonly double[] QuantomSizes;
        public MLFQ()
        {
            int numLevels = 3;
            QuantomSizes = new double[] { 8, 16, Double.PositiveInfinity };
            levels = new List<Queue<Process>>(numLevels);
            for (int i = 0; i < numLevels; i++)
            {
                levels.Add(new Queue<Process>());
            }
        }
        public override void AddProcess(Process p)
        {
            levels[0].Enqueue(p);
            base.AddProcess(p);
        }

        public override List<ProcessViewModel> Schedule()
        {
            var list = new List<ProcessViewModel>();
            int periority = 0;
            while(!levels.All(level => level.Count <= 0))
            {
                var level = levels[periority];

                while (level.Count > 0)
                {
                    if(!level.ToList().Any(p => p.ArrivalTime <= counter))
                    {
                        break;
                    }
                    var process = level.Peek();
                    if (process.ArrivalTime > counter)
                    {
                        counter++;
                        continue;
                    }
                    if (process.BurstTime > QuantomSizes[periority])
                    {
                        for (int i = 0; i < QuantomSizes[periority]; i++)
                        {
                            process.Excute();
                            counter++;
                            list.Add(Convert(process));
                        }
                        levels[periority + 1].Enqueue(level.Dequeue());
                    }
                    else
                    {
                        for (int i = 0; i < process.BurstTime; i++)
                        {
                            process.Excute();
                            counter++;
                            list.Add(Convert(process));
                        }
                        level.Dequeue();
                    }
                }
                periority = periority == QuantomSizes.Length - 1 ? 0 : periority + 1;
            }
            return list;
        }
    }
}
