using PS.Domain.Schedulers;

namespace PS.Domain
{
    public delegate void Notify(Process p);
    public class Process
    {
        public long Id { get; set; }
        public int BurstTime { get; set; }
        public int ArrivalTime { get; set; }
        public int Periority { get; set; }
        public int remainingTime;

        public Notify ProcessCompleted;


        public Process(long id, int burstTime, int arrivalTime, int periority)
        {
            Id = id;
            BurstTime = burstTime;
            ArrivalTime = arrivalTime;
            remainingTime = burstTime;
            Periority = periority;
        }
        public void Excute()
        {
            remainingTime--;
            if(remainingTime <= 0 )
            {
                ProcessCompleted.Invoke(this);
            }
        }

        internal bool Finished()
        {
            return remainingTime == 0;
        }
    }
}