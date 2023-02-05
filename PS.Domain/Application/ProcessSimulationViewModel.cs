using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain.Application
{
    public class ProcessSimulationViewModel
    {
        public List<ProcessViewModel> Processes { get; set; }
        public double AvrageTurnAroundTime { get; set; }
        public List<ProcessStatistics> statistics { get; set; }

    }
}
