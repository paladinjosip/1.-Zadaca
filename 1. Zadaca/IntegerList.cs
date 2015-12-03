using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int count = 0;

        public IntegerList() {
            _internalStorage = new int[4];
        }
        public IntegerList(int initialSize) {
            _internalStorage = new int[initialSize];
        }
        public void Add(int item)
        {
            if (this.Count >= _internalStorage.Length) {
                var placeHolder = new int[_internalStorage.Length * 2];
                Array.Copy(_internalStorage, placeHolder, _internalStorage.Length);
                _internalStorage = placeHolder;
            }
            _internalStorage[this.Count] = item;

            count++;
            
        }

        public bool Remove(int item)
        {
            return RemoveAt(IndexOf(item));
           
        }

        public bool RemoveAt(int index)
        {
            if (index >= this.Count || index == -1) return false;
            int i = index;
            do
            {
                _internalStorage[i] = _internalStorage[i + 1];
                i++;
                
            } while (i <= this.Count - 1);
                
            count--;
            return true;
                
        }

        public int GetElement(int index)
        {
            if (index >= this.Count) throw new IndexOutOfRangeException();
            return _internalStorage[index];
            
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < this.Count; i++)
                if (_internalStorage[i] == item) return i;
            return -1;
        }

        public int Count
        {

            get { return count; }
            
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(int item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
        }
    }
}
