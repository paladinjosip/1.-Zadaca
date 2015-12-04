using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    public class GenericList<X> : IGenericList<X>
    {
        private int count = 0;
        private X[] _internalStorage;

        public GenericList() {
          _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
          _internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (this.Count >= _internalStorage.Length)
            {
                var placeHolder = new X[_internalStorage.Length * 2];
                Array.Copy(_internalStorage, placeHolder, _internalStorage.Length);
                _internalStorage = placeHolder;
            }
            _internalStorage[this.Count] = item;

            count++;
            
        }

        public bool Remove(X item)
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

        public X GetElement(int index)
        {

            if (index >= this.Count) throw new IndexOutOfRangeException();
            return _internalStorage[index];
           
        }

        public int IndexOf(X item)
        {

            for (int i = 0; i < this.Count; i++)
                if (_internalStorage[i].Equals(item)) return i;
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

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
            
        }
    }
}
