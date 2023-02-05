using PS.Domain.Application;

namespace PS.Domain.Schedulers
{
    public class MLQ : BaseScheduler
    {
        private List<Level> levels;
        private int levelIndex;
        private int finishedLevels;
        public MLQ()
        {
            levels = new List<Level>();
            levelIndex = 0;
            finishedLevels = 0;
        }
        public override List<ProcessViewModel> Schedule()
        {
            var list = new List<ProcessViewModel>();
            Enqueue();
            while (finishedLevels < levels.Count)
            {
                list.AddRange(ScheduleLevel(levels[levelIndex]));
                if (levels[levelIndex].levelCompleted())
                {
                    finishedLevels++;
                }
                IncrementIndex();
            }
            return list;
        }
        private void Enqueue()
        {
            int minPeriority = processList.MaxBy(p => p.Periority).Periority;
            Level level = null;
            for (int i = 1; i <= minPeriority; i++)
            {
                level = new Level();
                var list = processList.Where(p => p.Periority == i).ToList();
                foreach (var item in list)
                {
                    level.processes.Add(item);
                }
                levels.Add(level);
            }
        }
        private List<ProcessViewModel> ScheduleLevel(Level level)
        {

            List<ProcessViewModel> list = new List<ProcessViewModel>();
            while (!level.levelCompleted() && level.processes.Any(p => p.ArrivalTime <= counter && !p.Finished()))
            {
                Process p = level.processes[level.index];
                if (p.ArrivalTime > counter)
                {
                    level.IncrementIndex();
                    p = level.processes[level.index];
                }
                if (!p.Finished())
                {
                    for (int i = 0; i < this.TimeQuantom; i++)
                    {
                        p.Excute();
                        list.Add(Convert(p));
                        counter++;
                        if (p.Finished()) 
                        {
                            level.FinishedProcesses++;
                            level.DecrementIndex();
                            break;
                        }
                    }
                }
                level.IncrementIndex();
            }
            return list;
        }
        private void IncrementIndex()
        {
            levelIndex = levelIndex == levels.Count - 1 ? 0 : levelIndex + 1;
        }

    }
    public class Level
    {
        public List<Process> processes;
        public int index;
        public int FinishedProcesses;

        public Level()
        {
            processes = new List<Process>();
            index = 0;
            FinishedProcesses = 0;
        }
        public void IncrementIndex()
        {
            index = index == processes.Count - 1 ? 0 : index + 1;
        }
        public void DecrementIndex()
        {
            index = index == 0 ? processes.Count - 1 : index - 1; 
        }
        public bool levelCompleted()
        {
            return FinishedProcesses >= processes.Count;
        }
    }
}
