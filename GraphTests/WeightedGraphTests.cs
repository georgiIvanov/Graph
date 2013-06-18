using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightedGraph;

namespace GraphTests
{
    [TestClass]
    public class WeightedGraphTests
    {
        [TestMethod]
        public void WeightedMST()
        {
            WeightedGraph<char> graph = new WeightedGraph<char>(6);

            graph.Add('A');  //0
            graph.Add('B');  //1
            graph.Add('C');  //2
            graph.Add('D');  //3
            graph.Add('E');  //4

            graph.AttachEdge(0, 1, 1);
            graph.AttachEdge(0, 2, 2);
            graph.AttachEdge(0, 3, 4);
            graph.AttachEdge(0, 4, 4);

            graph.AttachEdge(1, 2, 1);
            graph.AttachEdge(1, 3, 3);
            graph.AttachEdge(1, 4, 4);

            graph.AttachEdge(2, 3, 1);
            graph.AttachEdge(2, 4, 4);

            graph.AttachEdge(3, 4, 1);


            string result = graph.MinimalSpanningTree();
            Assert.AreEqual("A:B B:C C:D D:E ", result);
        }

        [TestMethod]
        public void WeightedMST2()
        {
            WeightedGraph<char> graph = new WeightedGraph<char>(6);

            graph.Add('A');  //0
            graph.Add('B');  //1
            graph.Add('C');  //2
            graph.Add('D');  //3
            graph.Add('E');  //4

            graph.AttachEdge(0, 1, 4);
            graph.AttachEdge(0, 2, 4);
            graph.AttachEdge(0, 3, 4);
            graph.AttachEdge(0, 4, 1);

            graph.AttachEdge(1, 2, 4);
            graph.AttachEdge(1, 3, 4);
            graph.AttachEdge(1, 4, 1);

            graph.AttachEdge(2, 3, 4);
            graph.AttachEdge(2, 4, 1);

            graph.AttachEdge(3, 4, 2);


            string result = graph.MinimalSpanningTree();
            Assert.AreEqual("A:E E:C E:D D:B ", result);
        }

        [TestMethod]
        public void ShortestPathsFromSource()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(0);
            string expected = "Minimal path between vertices 0 and 1: 0 1 , length of path: 23\nMinimal path between vertices 0 and 2: 0 1 3 2 , length of path: 32\nMinimal path between vertices 0 and 3: 0 1 3 , length of path: 26\nNo path between vertices 0 and 4\nNo path between vertices 0 and 5\nMinimal path between vertices 0 and 6: 0 1 6 , length of path: 57\nMinimal path between vertices 0 and 7: 0 7 , length of path: 8\nNo path between vertices 0 and 8\nMinimal path between vertices 0 and 9: 0 7 9 , length of path: 38";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath0to1()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(0, 1);
            string expected = "Minimal path between vertices 0 and 1: 0 1 , length of path: 23";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath0to2()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(0, 2);
            string expected = "Minimal path between vertices 0 and 2: 0 1 3 2 , length of path: 32";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath0to4()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(0, 4);
            string expected = "No path between vertices 0 and 4";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath0to6()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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
            string expected = "Minimal path between vertices 0 and 6: 0 1 6 , length of path: 57";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath0to8()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(0, 8);
            string expected = "No path between vertices 0 and 8";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShortestPath1to7()
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(10);
            for (int i = 0; i < 10; i++)
            {
                graph.Add(i);
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


            string result = graph.FindShortestPath(1, 7);
            string expected = "Minimal path between vertices 1 and 7: 1 0 7 , length of path: 31";

            Assert.AreEqual(expected, result);
        }
    }
}
