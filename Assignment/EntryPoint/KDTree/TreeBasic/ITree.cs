using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    interface ITree<T>
    {
        bool IsEmpty { get; }
        T Value { get; }
        ITree<T> Left { get; }
        ITree<T> Right { get; }
    }
}
