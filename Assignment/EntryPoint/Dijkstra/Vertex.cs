using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Vertex<T>
    {
        public T Value;
        public List<Edge<T>> Adjancies;
        public int MinimalDistance = int.MaxValue;
        public Vertex<T> Previous;

        public Vertex(T value)
        {

            Value = value;
        }
    }
}
