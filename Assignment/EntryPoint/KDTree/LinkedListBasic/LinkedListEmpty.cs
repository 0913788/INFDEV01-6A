using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class LinkedListEmpty<T> : ILinkedList<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public ILinkedList<T> Tail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void RemoveTail()
        {
            throw new NotImplementedException();
        }

        public List<T> ToList()
        {
            return new List<T>();
        }
    }
}
