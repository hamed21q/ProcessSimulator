using MS.Domain.Entity.algo;

namespace MS.Domain.Entity
{
    public class FreeListAlgorithemFactory
    {
        public FreeListAlgorithem GetAlgorithem(string id)
        {
            switch (id)
            {
                case "BestFit":
                    return new BestFit();
                case "FirstFit":
                    return new FirstFit();
                case "WorstFit":
                    return new WorstFit();
                default:
                    throw new ArgumentException();
            }
        }
    }
}