using PS.Domain.Application;
using PS.Domain.Schedulers;

namespace PS.Domain
{
    public class CPU
    {
        private readonly SchedulerFactory factory;
        public IScheduler scheduler;

        public CPU(SchedulerFactory factory)
        {
            this.factory = factory;
        }
        public ProcessSimulationViewModel Process(CreateProcessSimulationCommand command)
        {
            scheduler = factory.GetScheduler(command.Algorithm);
            for (int i = 0; i < command.processes.Count; i++)
            {
                var processVm = command.processes[i];
                var p = Convert(processVm, i);
                p.ProcessCompleted += scheduler.RemoveProcess;
                scheduler.AddProcess(p);
                scheduler.TimeQuantom = command.TimeQuantom;
            }
            var list = scheduler.Schedule();
            return new ProcessSimulationViewModel
            {
                Processes = list
            };
        }
        private Process Convert(CreateProcessCommand command, long id)
        {
            return new Process(id, command.BurstTime, command.ArrivalTime, command.Periority);
        }
    }
}
