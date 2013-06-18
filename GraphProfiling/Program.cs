using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using WeightedGraph;

namespace GraphProfiling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph<char> graph = new Graph<char>(6);

            //graph.Add('A');
            //graph.Add('B');
            //graph.Add('C');
            //graph.Add('D');
            //graph.Add('E');
            //graph.Add('F');

            //graph.AttachEdge(0, 2);
            //graph.AttachEdge(0, 3);
            //graph.AttachEdge(1, 4);
            //graph.AttachEdge(2, 5);

            //Console.WriteLine("Breadth First Search");

            //bool result = graph.BreadthFirstSearch(0, 3);

            //if (result)
            //{
            //    Console.WriteLine("\nPath found!");
            //}
            //else
            //{
            //    Console.WriteLine("\nPath NOT found!");
            //}

            //Console.WriteLine("Depth First Search");
            //result = graph.DepthFirstSearch(0, 3);
            //if (result)
            //{
            //    Console.WriteLine("\nPath found!");
            //}
            //else
            //{
            //    Console.WriteLine("\nPath NOT found!");
            //}


            //Console.WriteLine("\nMinimum Spanning Tree: \n");

            //Console.WriteLine(graph.MinimalSpanningTree());

            //TOPOLOGICAL SORT
            //Console.WriteLine("Topological Sorting");

            //Graph<char> graph = new Graph<char>(6);
            //graph.Add('A');
            //graph.Add('B');
            //graph.Add('C');
            //graph.Add('D');
            //graph.Add('E');
            //graph.Add('F');

            //graph.AttachDirectedEdge(0, 1);
            //graph.AttachDirectedEdge(0, 2);
            //graph.AttachDirectedEdge(1, 3);
            //graph.AttachDirectedEdge(2, 4);
            //graph.AttachDirectedEdge(3, 4);
            //graph.AttachDirectedEdge(4, 5);

            //List<char> result = new List<char>();
            //if (graph.TopologicalSort(result) == true)
            //{
            //    Console.Write("Topological sort: ");
            //    result.Reverse();
            //    foreach (var item in result)
            //    {
            //        Console.Write("{0} ", item);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("There are cycles in graph!");
            //}

            //WEIGHTED GRAPH
            //Console.WriteLine("Weighted graph");
            //WeightedGraph<char> graph = new WeightedGraph<char>(5);

            //graph.Add('A');
            //graph.Add('B');
            //graph.Add('C');
            //graph.Add('D');
            //graph.Add('E');

            //graph.AttachEdge(0, 1, 1);
            //graph.AttachEdge(0, 2, 2);
            //graph.AttachEdge(0, 3, 4);
            //graph.AttachEdge(0, 4, 4);
                  
            //graph.AttachEdge(1, 2, 1);
            //graph.AttachEdge(1, 3, 3);
            //graph.AttachEdge(1, 4, 4);
                  
            //graph.AttachEdge(2, 3, 1);
            //graph.AttachEdge(2, 4, 4);
                  
            //graph.AttachEdge(3, 4, 1);

            //string result = graph.MinimalSpanningTree();
            //Console.WriteLine("Minimal Spanning Tree: {0}", result);

            WeightedGraph<char> graph = new WeightedGraph<char>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add((char)(i+65));
            }

            graph.AttachEdge(0, 1, 23);
            graph.AttachEdge(0, 7, 8);

            graph.AttachEdge(1, 3, 3);
            graph.AttachEdge(1, 6, 34);

            graph.AttachEdge(2, 3, 6);
            graph.AttachEdge(2, 7, 25);
            graph.AttachEdge(2, 9, 7);

            graph.AttachEdge(4, 5, 10);

            graph.AttachEdge(7, 9, 30);


            string result = graph.FindShortestPath(0, 6);
            Console.WriteLine(result);
        }
    }
}
