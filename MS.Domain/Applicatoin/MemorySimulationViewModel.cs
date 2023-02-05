using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.Applicatoin
{
    public class MemorySimulationViewModel
    {
        public long Id { get; set; }
        public int Size { get; set; }
        public int Address { get; set; }
        public bool isValid { get; set; }

    }
}
