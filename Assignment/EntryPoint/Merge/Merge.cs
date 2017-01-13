using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Merge
    {
        Vector2 _baseValue;

        public Merge(Vector2 baseValue)
        {
            _baseValue = baseValue;
        }

        private bool Compare(Vector2 LeftSideValue, Vector2 RightSideValue)
        { 
            double LeftDistance = Math.Sqrt(Math.Pow((_baseValue.X - LeftSideValue.X), 2) + Math.Pow((_baseValue.Y - LeftSideValue.Y), 2));
            double RightDistance = Math.Sqrt(Math.Pow((_baseValue.X - RightSideValue.X), 2) + Math.Pow((_baseValue.Y - RightSideValue.Y), 2));
            return LeftDistance <= RightDistance;
        }

        public void Run(Vector2[] data, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            Vector2[] L = new Vector2[n1];
            Vector2[] R = new Vector2[n2];

            for (i = 0; i < n1; i++)
                L[i] = data[left + i];

            for (j = 0; j < n2; j++)
                R[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (Compare(L[i],R[j]))
                {
                    data[k] = L[i];
                    i++;
                }
                else
                {
                    data[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                data[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = R[j];
                j++;
                k++;
            }
        }
    }
}