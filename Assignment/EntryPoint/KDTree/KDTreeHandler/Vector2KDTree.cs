using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Vector2KDTreeHandler : IKDTreeHandler<Vector2>
    {

        public ITree<Vector2> CreateTree(IEnumerable<Vector2> list)
        {
            ITree<Vector2> tree = new TreeEmpty<Vector2>();
            List<Vector2> handled = new List<Vector2>();
            int listLength = list.Count();
            int MedianLeft = listLength / 2;
            int MedianRight = MedianLeft + MedianLeft / 2;

            for (int i = 0; i < 4; i++)
            {
                tree = Insert(tree,list.ElementAt(MedianLeft));
                handled.Add(list.ElementAt(MedianLeft));
                tree = Insert(tree, list.ElementAt(MedianRight));
                handled.Add(list.ElementAt(MedianRight));
                MedianLeft = MedianLeft / 2;
                MedianRight = MedianRight + ((listLength - MedianRight) / 2);
            }

            foreach(Vector2 vector in list)
            {
                if (!handled.Contains(vector))
                {
                    tree = Insert(tree, vector);
                }
            }

            return tree;      
        }

        public ITree<Vector2> Insert(ITree<Vector2> tree, Vector2 value, bool XAxis = true)
        {
            if (tree.IsEmpty) return new TreeNode<Vector2>(new TreeEmpty<Vector2>(), value, new TreeEmpty<Vector2>());
            if (InsertCompare(value, tree.Value, XAxis)) return new TreeNode<Vector2>(Insert(tree.Left, value, !XAxis), tree.Value, tree.Right);
            else return new TreeNode<Vector2>(tree.Left, tree.Value, Insert(tree.Right, value, !XAxis));
        }

        public bool InsertCompare(Vector2 insertValue, Vector2 treeValue, bool XAxis)
        {
            if (XAxis) return insertValue.X <= treeValue.X;
            else return insertValue.Y <= treeValue.Y;
        }

        public int RangeCompare(Window2D<Vector2> window, Vector2 value, bool XAxis)
        {
            int returnInt = 0;
            if (XAxis)
            {
                if(value.X >= window.LeftBottom.X && value.X <= window.RightBottom.X)
                {
                    returnInt = 1;
                }
                else
                {
                    if(value.X < window.LeftBottom.X)
                    {
                        returnInt = 3;
                    }
                    else
                    {
                        if(value.X > window.RightBottom.X)
                        {
                            returnInt = 2;
                        }
                    }
                }
            }
            else
            {
                if(value.Y >= window.LeftBottom.Y && value.Y <= window.LeftTop.Y)
                {
                    returnInt = 1;
                }
                else
                {
                    if(value.Y < window.LeftBottom.Y)
                    {
                        returnInt = 3;
                    }
                    else
                    {
                        if (value.Y > window.LeftTop.Y)
                        {
                            returnInt = 2;
                        }
                    }
                }
            }
            return returnInt;
        }

        public ILinkedList<Vector2> RangeSearch(Window2D<Vector2> window, ITree<Vector2> tree, bool XAxis, ILinkedList<Vector2> LinkedList = null)
        {
            if (LinkedList== null) { LinkedList = new LinkedListEmpty<Vector2>(); }
            if (!tree.IsEmpty)
            {
                int compareInt = RangeCompare(window, tree.Value, XAxis);
                switch (compareInt)
                {
                    case 1: //Within window
                        LinkedList = new LinkedListNode<Vector2>(tree.Value, LinkedList);
                        LinkedList = RangeSearch(window, tree.Right, !XAxis, LinkedList);
                        LinkedList = RangeSearch(window, tree.Left, !XAxis, LinkedList);
                        break;
                    case 2: //Above window
                        LinkedList = RangeSearch(window, tree.Left, !XAxis, LinkedList);
                        break;
                    case 3: //Below window
                        LinkedList = RangeSearch(window, tree.Right, !XAxis, LinkedList);
                        break;
                }
            }
            return LinkedList;
        }
    }
}
