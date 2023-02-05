using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.Entity.algo
{
    public class FirstFit : FreeListAlgorithem 
    {
        public override int Allocate(int size)
        {
            Block prev = null;
            Block current = head;

            while (current != null && current.Size < size)
            {
                prev = current;
                current = current.Next;
            }

            if (current == null)
            {
                return -1;
            }

            if (current.Size == size)
            {
                if (prev == null)
                {
                    head = current.Next;
                }
                else
                {
                    prev.Next = current.Next;
                }
            }
            else
            {
                current.Size -= size;
                current.Address += size;
            }

            return current.Address;
        }
    }
}
