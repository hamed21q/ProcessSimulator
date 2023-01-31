using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Application
{
    public class ProcessViewModel
    {
        public long Id { get; set; }
        public int BurstTime { get; set; }
        public int ArrivalTime { get; set;}
        public int RemainingTime { get; set; }
        public int Periority { get; set; }
    }
}
