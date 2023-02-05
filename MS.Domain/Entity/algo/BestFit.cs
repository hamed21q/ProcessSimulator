using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.Entity.algo
{
    public class BestFit : FreeListAlgorithem
    {
        public override int Allocate(int size)
        {
            Block prev = null;
            Block current = head;
            Block best = new Block(0, 0);
            Block beforeBest = null;
            while (current != null)
            {   
                if(best.Size - size > current.Size - size && current.Size >= size)
                {
                    best = current;
                    beforeBest = prev;
                }
                prev = current;
                current = current.Next;
            }
            if (best.Size == 0)
                throw new ArgumentException();

            if (best.Size == size)
            {
                if (beforeBest == null)
                {
                    head = best.Next;
                }
                else
                {
                    beforeBest.Next = best.Next;
                }
            }
            else
            {
                best.Size -= size;
                best.Address += size;
            }
            return best.Address;
        }
    }
}
