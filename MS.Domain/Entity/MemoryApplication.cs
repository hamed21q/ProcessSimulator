using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MS.Domain.Applicatoin;
using MS.Domain.Entity.algo;
using MS.Domain.repository;

namespace MS.Domain.Entity
{
    public class MemoryApplication
    {
        private readonly Context context;
        private readonly FreeListAlgorithemFactory factory;
        private MemorySimulationViewModel[] storage;
        private FreeListAlgorithem algo;
        public MemoryApplication(Context context, FreeListAlgorithemFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public MemorySimulationViewModel[] Schedule(CreateMemoryProcessCommand command)
        {
            var sim = context.Simulations.Find(command.SimulationId);
            algo = factory.GetAlgorithem(sim.Algorithem);
            storage = new MemorySimulationViewModel[sim.StorageSize];
            algo.AddBlock(sim.StorageSize, 0);
            return storage;
        }
        private void allocateOlders()
        {
            var list = context.Processes.ToList();
            foreach (var item in list)
            {
                algo.Allocate(item.Size);
                for (int i = 0; i < item.Size; i++)
                {
                    storage[item.Address + i] = Convert(item);
                }
            }
        }
        public MemorySimulationViewModel[] DeAllocate(long id)
        {
            var p = context.Processes.Find(id);
            var simulation = context.Simulations.Find(p.SimulationId);
            algo = factory.GetAlgorithem(simulation.Algorithem);
            storage = new MemorySimulationViewModel[simulation.StorageSize];
            allocateOlders();
            context.Processes.Remove(p);
            context.SaveChanges();
            algo.Deallocate(p.Address, p.Size);
            for (int i = 0; i < p.Size; i++)
            {
                storage[p.Address + i] = null;
            }

            return storage;
        }
        public void AddSimulation(CreateSimulationCommand command)
        {
            var simulation = new Simulation(command.Algorithem, command.storageSize);
            context.Simulations.Add(simulation);
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            var processes = context.Processes.ToList();
            context.Processes.RemoveRange(processes);
            context.SaveChanges();
        }
        private MemorySimulationViewModel Convert(Process p)
        {
            return new MemorySimulationViewModel
            {
                Id = p.Id,
                Address = p.Address,
                isValid = true,
                Size = p.Size
            };
        } 
    }
}
