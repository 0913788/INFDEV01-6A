using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class MergeSort
    {
        public void Run(Vector2[] Array, int p, int r, Vector2 _baseValue)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                new MergeSort().Run(Array, p, q, _baseValue);
                new MergeSort().Run(Array, q + 1, r, _baseValue);
                new Merge(_baseValue).Run(Array, p, q, r);
            }
        }
    }
}
