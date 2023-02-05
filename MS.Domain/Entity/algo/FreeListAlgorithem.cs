namespace MS.Domain.Entity.algo
{
    public class FreeListAlgorithem
    {
        protected class Block
        {
            public int Size;
            public int Address;
            public Block Next;

            public Block(int size, int address)
            {
                Size = size;
                Address = address;
                Next = null;
            }
        }

        protected Block head;

        public FreeListAlgorithem()
        {
            head = null;
        }

        public void AddBlock(int size, int address)
        {
            Block block = new Block(size, address);
            block.Next = head;
            head = block;
        }

        public virtual int Allocate(int size)
        {
            return -1;
        }

        public void Deallocate(int address, int size)
        {
            AddBlock(size, address);
        }
    }
}
