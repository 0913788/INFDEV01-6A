using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    interface ILinkedList<T>
    {
        bool IsEmpty { get; }
        T Value { get; }
        ILinkedList<T> Tail { get; }
        void RemoveTail();
        List<T> ToList();
    }
}
