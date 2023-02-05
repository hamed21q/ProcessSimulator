using PS.Domain.Application;
using PS.Domain.Schedulers;

namespace PS.Domain
{
    public class CPU
    {
        private readonly SchedulerFactory factory;
        public IScheduler scheduler;
        private readonly string[] algorithms = new string[] { "FCFS", "RN", "MLQ", "MLFQ", "PR", "SJF", "SRT" };

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
                p.ProcessCompleted += scheduler.SaveTurnAroundTime;
                p.ProcessCompleted += scheduler.SaveWaitingTime;
                p.ProcessStarted += scheduler.SaveResponseTime;
                scheduler.AddProcess(p);
                scheduler.TimeQuantom = command.TimeQuantom;
            }
            var list = scheduler.Schedule();
            return new ProcessSimulationViewModel
            {
                Processes = list,
                AvrageTurnAroundTime = 0,
                statistics = scheduler.CalculateStatistics()
            };
        }
        private Process Convert(CreateProcessCommand command, long id)
        {
            return new Process(id, command.BurstTime, command.ArrivalTime, command.Periority);
        }
        public AlgorithmComparisonViewModel Compare (CreateAlgorithmComparisonCommand command)
        {
            var results = new ProcessSimulationViewModel[algorithms.Length];
            for (int i = 0; i < algorithms.Length; i++)
            {
                results[i] = Process(new CreateProcessSimulationCommand
                {
                    Algorithm = algorithms[i],
                    processes = command.processes,
                    TimeQuantom = command.TimeQuantom
                });
            }
            var comparisonResult = new List<AlgorithmStat>();
            for (int i = 0; i < results.Length; i++)
            {
                comparisonResult.Add(new AlgorithmStat
                {
                    Name = algorithms[i],
                    ResponsTimeAVG = Math.Round(results[i].statistics.Average(s => s.ResponseTime), 1),
                    TurnAroundTimeAVG = Math.Round(results[i].statistics.Average(s => s.TurnAroundTime), 1),
                    WaitingTimeAVG = Math.Round(results[i].statistics.Average(s => s.ResponseTime), 1)
                });
                /*comparisonResult.Add(new AlgorithmStat
                {
                    Name = algorithms[i],
                    ResponsTimeAVG = results[i].statistics.Sum(s => s.ResponseTime),
                    TurnAroundTimeAVG = results[i].statistics.Sum(s => s.TurnAroundTime),
                    WaitingTimeAVG = results[i].statistics.Sum(s => s.ResponseTime)
                });*/
            }
            return new AlgorithmComparisonViewModel
            {
                algorithmStats = comparisonResult
            };
        }
    }
}
