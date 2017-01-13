using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class TreeEmpty<T> : ITree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public ITree<T> Left
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITree<T> Right
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
    }
}
