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
        Vector2 BaseValue;
        
        public MergeSort(Vector2 baseValue)
        {
            BaseValue = baseValue;
        }
        public void Run(Vector2[] Array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                new MergeSort(BaseValue).Run(Array, left, mid);
                new MergeSort(BaseValue).Run(Array, mid + 1, right);
                new Merge(BaseValue).Run(Array, left, mid, right);
            }
        }
    }
}
