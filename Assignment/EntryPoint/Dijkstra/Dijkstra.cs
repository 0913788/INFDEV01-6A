using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Dijkstra<T>
    {
        public void CreatePaths(Vertex<T> Origin)
        {
            Origin.MinimalDistance = 0;
            Vertex<T> currentVertex = null;
            Vertex<T> VisitingVertex = null;
            List<Vertex<T>> vertexQueue = new List<Vertex<T>>();
            vertexQueue.Add(Origin);
            int lowestDistance;

            while (vertexQueue.Count > 0)
            {
                foreach(Vertex<T> vertex in vertexQueue)
                {
                    lowestDistance = int.MaxValue;
                    if(currentVertex == null || lowestDistance > vertex.MinimalDistance)
                    {
                        currentVertex = vertex;
                    }
                }

                foreach(Edge<T> edge in currentVertex.Adjancies)
                {
                    VisitingVertex = edge.Target;
                    if (currentVertex.MinimalDistance + edge.Weight < VisitingVertex.MinimalDistance)
                    { 
                        VisitingVertex.MinimalDistance = currentVertex.MinimalDistance + edge.Weight;
                        VisitingVertex.Previous = currentVertex;
                        vertexQueue.Add(VisitingVertex);
                    }           
                }
                vertexQueue.Remove(currentVertex);
            }
        }

        public List<Tuple<T, T>> GetShortestPath(Vertex<T> target)
        {
            List<Tuple<T, T>> returnList = new List<Tuple<T, T>>();

            while (target.Previous != null)
            {
                returnList.Add(new Tuple<T, T>(target.Previous.Value, target.Value));
                target = target.Previous;
            }
            returnList.Reverse();
            return returnList;
        }
    }
}
