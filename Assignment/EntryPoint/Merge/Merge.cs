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
        Vector2 BaseValue;

        public Merge(Vector2 baseValue)
        {
            BaseValue = baseValue;
        }

        private bool Compare(Vector2 LeftSideValue, Vector2 RightSideValue)
        { 
            double LeftDistance = Math.Sqrt(Math.Pow((BaseValue.X - LeftSideValue.X), 2) + Math.Pow((BaseValue.Y - LeftSideValue.Y), 2));
            double RightDistance = Math.Sqrt(Math.Pow((BaseValue.X - RightSideValue.X), 2) + Math.Pow((BaseValue.Y - RightSideValue.Y), 2));
            return LeftDistance <= RightDistance;
        }

        public void Run(Vector2[] data, int left, int mid, int right)
        {
            int i, j, k;
            int leftArrayLen = mid - left + 1;
            int rightArrayLen = right - mid;
            Vector2[] leftArray = new Vector2[leftArrayLen];
            Vector2[] rightArray = new Vector2[rightArrayLen];

            for (i = 0; i < leftArrayLen; i++)
                leftArray[i] = data[left + i];

            for (j = 0; j < rightArrayLen; j++)
                rightArray[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < leftArrayLen && j < rightArrayLen)
            {
                if (Compare(leftArray[i],rightArray[j]))
                {
                    data[k] = leftArray[i];
                    i++;
                }
                else
                {
                    data[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftArrayLen)
            {
                data[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < rightArrayLen)
            {
                data[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}