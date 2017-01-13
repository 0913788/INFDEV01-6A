using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Window2D<T>
    {
        public Window2D(T leftTop, T rightTop, T rightBottom, T leftBottom)
        {
            LeftTop = leftTop;
            RightTop = rightTop;
            RightBottom = rightBottom;
            LeftBottom = leftBottom;
        }
             
        public T LeftTop { get; set; }
        public T RightTop { get; set; }
        public T RightBottom { get; set; }
        public T LeftBottom { get; set; }
    }
}
