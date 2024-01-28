using Merlin2d.Game.Items;
using System.Collections;

namespace StarryNight.Items
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        
        private int capacity;
        public int position;

        public Backpack(int capacity)
        {
            this.items = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            try
            {
                this.items[this.position++] = item;
            }
            catch
            {
                throw new Exception("Inventory is full!");
            }

        }

        public int GetCapacity()
        {
            return this.capacity;
        }
        
        public IEnumerator<IItem> GetEnumerator()
        {
            foreach(IItem item in items)
            {
                if (item == null)
                {
                    continue;
                }
                yield return item;
            }
        }

        public IItem GetItem()
        {
            foreach (IItem item in items)
            {
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        public void RemoveItem(IItem item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].GetType() == item.GetType())
                {
                    this.items[i] = null;
                    break;
                }
            }
        }

        public void RemoveItem(int index)
        {
            this.items[index] = null;
        }

        public void ShiftLeft()
        {
            IItem[] potion = new IItem[this.items.Length];
            int nil = 0;
            
            foreach(IItem item in this.items)
            {
                if (item == null)
                {
                    nil++;
                }
            }
            
            for (int i = 0; i < items.Length - 1 - nil; i++)
            {
                potion[i] = this.items[i + 1];
            }

            potion[potion.Length - 1 - nil] = this.items[0];
            this.items = potion;
        }

        public void ShiftRight()
        {
            IItem[] potion = new IItem[this.items.Length];
            int nil = 0;
            foreach (IItem item in this.items)
            {
                if (item == null)
                {
                    nil++;
                }
            }

            for (int i = 1; i < this.items.Length - nil; i++)
            {
                potion[i] = this.items[i - 1];
            }

            potion[0] = this.items[items.Length - 1 - nil];
            this.items = potion;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
