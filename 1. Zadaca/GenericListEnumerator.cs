using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
   public class GenericListEnumerator<T> : IEnumerator<T>
    {
       private IGenericList<T> _collection;
       private int currentIndex = -1;

       public GenericListEnumerator(IGenericList<T> collection)
       {
           _collection = collection;
       }
        public T Current
        {
            get { return _collection.GetElement(currentIndex); }
        }



        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            // Zove se prije svake iteracije.
            // Vratite true ako treba ući u iteraciju, false ako ne
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se nalazimo u kolekciji
            return (++currentIndex < _collection.Count);
          
        }

        public void Reset()
        {
            
        }
        public void Dispose()
        {
          
        }
    }
}
