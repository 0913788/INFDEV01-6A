using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Edge<T>
    {
        public Vertex<T> Target;
        public int Weight;
        public Edge(Vertex<T> target, int weight)
        {
            Target = target;
            Weight = weight;
        }
    }
}
