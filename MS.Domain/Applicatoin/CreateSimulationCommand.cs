using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.Applicatoin
{
    public class CreateSimulationCommand
    {
        public string Algorithem { get; set; }
        public int storageSize { get; set; }
    }
}
