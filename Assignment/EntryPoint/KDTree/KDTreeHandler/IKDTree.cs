using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    interface IKDTreeHandler<T>
    {

        ITree<T> Insert(ITree<T> tree, T value, bool XAxis = true);

        ILinkedList<T> RangeSearch(Window2D<T> window, ITree<T> tree, bool XAxis, ILinkedList<T> LinkedList=null);

        bool InsertCompare(T treeValue, T insertValue, bool XAxis);

        int RangeCompare(Window2D<T> window, T value, bool XAxis);
    }
}
