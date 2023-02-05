using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.repository
{
    public class Simulation
    {
        public long Id { get; set; }
        public string Algorithem { get; set; }
        public int StorageSize { get; set; }

        public virtual List<Process> Processs { get; set; }
        public Simulation(string algo, int size) 
        {
            Algorithem = algo;
            StorageSize = size;
        }
        public Simulation()
        {

        }
    }
}
