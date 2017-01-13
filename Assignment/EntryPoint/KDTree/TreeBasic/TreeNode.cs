using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class TreeNode<T> : ITree<T>
    {
        public TreeNode(ITree<T> left, T value, ITree<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }
        public ITree<T> Left { get; set; }

        public ITree<T> Right { get; set; }

        public T Value { get; set; }
    }
}
