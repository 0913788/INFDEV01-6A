using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
#if WINDOWS || LINUX
  public static class Program
  {

    [STAThread]
    static void Main()
    {

      var fullscreen = false;
      read_input:
      switch (Microsoft.VisualBasic.Interaction.InputBox("Which assignment shall run next? (1, 2, 3, 4, or q for quit)", "Choose assignment", VirtualCity.GetInitialValue()))
      {
        case "1":
          using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance, fullscreen))
            game.Run();
          break;
        case "2":
          using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse, fullscreen))
            game.Run();
          break;
        case "3":
          using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
            game.Run();
          break;
        case "4":
          using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
            game.Run();
          break;
        case "q":
          return;
      }
      goto read_input;
    }

    private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
    {
        Vector2[] sB = specialBuildings.ToArray();
        new MergeSort().Run(sB, 0, specialBuildings.Count()-1, house);
        IEnumerable<Vector2> x = specialBuildings.OrderBy(v => Vector2.Distance(v, house));
        return sB;
    }

    private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(
      IEnumerable<Vector2> specialBuildings, 
      IEnumerable<Tuple<Vector2, float>> housesAndDistances)
    {
            List<Vector2> tmpList = new List<Vector2>();
            List<List<Vector2>> endList = new List<List<Vector2>>();
            Vector2KDTreeHandler handler = new Vector2KDTreeHandler();
            ITree<Vector2> tree = handler.CreateTree(specialBuildings);

            foreach(Tuple<Vector2, float> house in housesAndDistances)
            {
                Window2D<Vector2> window = new Window2D<Vector2>(new Vector2(house.Item1.X - house.Item2 , house.Item1.Y + house.Item2), 
                                                                 new Vector2(house.Item1.X + house.Item2, house.Item1.Y + house.Item2), 
                                                                 new Vector2(house.Item1.X + house.Item2, house.Item1.Y - house.Item2), 
                                                                 new Vector2(house.Item1.X - house.Item2, house.Item1.Y - house.Item2));
                foreach (Vector2 vector in handler.RangeSearch(window, tree, true).ToList())
                {
                    if (Math.Sqrt(Math.Pow((house.Item1.X - vector.X), 2) + Math.Pow((house.Item1.Y - vector.Y), 2)) <= house.Item2)
                    {
                        tmpList.Add(vector);
                    }
                }
                endList.Add(tmpList);
            }
            return endList;
    }

    private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding, 
      Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
    {
            List<Vertex<Vector2>> vertexList = new List<Vertex<Vector2>>();
            Vector2 StartPoint, EndPoint;
            Vertex<Vector2> CurrentVertex, EndVertex, startingVertex, destinationVertex;
            startingVertex = new Vertex<Vector2>(startingBuilding);
            destinationVertex = new Vertex<Vector2>(destinationBuilding);
            //destinationVertex = new Vertex<Vector2>(new Vector2(20,20));

            vertexList.Add(startingVertex);
            vertexList.Add(destinationVertex);


            foreach (Tuple<Vector2,Vector2> tuple in roads)
            {
                StartPoint = tuple.Item1;
                EndPoint = tuple.Item2;
                CurrentVertex = null;
                EndVertex = null;
                foreach(Vertex<Vector2> vertex in vertexList)
                {
                    if (CurrentVertex == null || EndVertex == null)
                    {
                        if (CurrentVertex == null)
                        {
                            if (vertex.Value == StartPoint)
                            {
                                CurrentVertex = vertex;
                            }
                        }
                        if (EndVertex == null)
                        {
                            if (vertex.Value == EndPoint)
                            {
                                EndVertex = vertex;
                            }
                        }
                    }
                    else { break; }
                }
                if (CurrentVertex == null) {CurrentVertex = new Vertex<Vector2>(StartPoint); vertexList.Add(CurrentVertex);}
                if (EndVertex == null) { EndVertex = new Vertex<Vector2>(EndPoint); ; vertexList.Add(EndVertex); }
                if (CurrentVertex.Adjancies == null) { CurrentVertex.Adjancies = new List<Edge<Vector2>>(); }
                CurrentVertex.Adjancies.Add(new Edge<Vector2>(EndVertex, 1));

            }
            Dijkstra<Vector2> dijkstra = new Dijkstra<Vector2>();
            dijkstra.CreatePaths(startingVertex);

            return dijkstra.GetShortestPath(destinationVertex);
    }

    private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding, 
      IEnumerable<Vector2> destinationBuildings, IEnumerable<Tuple<Vector2, Vector2>> roads)
    {
      List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
      foreach (var d in destinationBuildings)
      {
        var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
        List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
        var prevRoad = startingRoad;
        for (int i = 0; i < 30; i++)
        {
          prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
          fakeBestPath.Add(prevRoad);
        }
        result.Add(fakeBestPath);
      }
      return result;
    }
  }
#endif
}
