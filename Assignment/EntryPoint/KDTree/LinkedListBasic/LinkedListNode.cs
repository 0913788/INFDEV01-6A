using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class LinkedListNode<T> : ILinkedList<T>
    {
        public LinkedListNode(T value, ILinkedList<T> tail)
        {
            Value = value;
            Tail = tail;
        }

        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }

        public ILinkedList<T> Tail
        { get; set; }

        public T Value
        { get; set; }

        public void RemoveTail()
        {
            Tail = null;
        }

        public List<T> ToList()
        {
            List<T> returnList = new List<T>();
            ILinkedList<T> element = this;
            while (!element.IsEmpty)
            {
                returnList.Add(element.Value);
                element = element.Tail;
            }
            return returnList;
        }
    }
}
