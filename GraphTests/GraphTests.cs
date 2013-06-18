using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Graph;

namespace GraphTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TopologicalSorting()
        {
            Graph<char> graph = new Graph<char>(6);
            graph.Add('A');  //0
            graph.Add('B');  //1
            graph.Add('C');  //2
            graph.Add('D');  //3
            graph.Add('E');  //4
            graph.Add('F');  //5

            graph.AttachDirectedEdge(0, 1);
            graph.AttachDirectedEdge(0, 2);
            graph.AttachDirectedEdge(1, 3);
            graph.AttachDirectedEdge(2, 4);
            graph.AttachDirectedEdge(3, 4);
            graph.AttachDirectedEdge(4, 5);

            List<char> result = new List<char>();

            Assert.IsTrue(graph.TopologicalSort(result));

            result.Reverse();

            Assert.AreEqual('A', result[0]);
            Assert.AreEqual('B', result[1]);
            Assert.AreEqual('D', result[2]);
            Assert.AreEqual('C', result[3]);
            Assert.AreEqual('E', result[4]);
            Assert.AreEqual('F', result[5]);

        }

        [TestMethod]
        public void TopologicalSorting2()
        {
            Graph<int> graph = new Graph<int>(8);
            graph.Add(7);  //0
            graph.Add(5);  //1
            graph.Add(3);  //2
            graph.Add(11); //3
            graph.Add(8);  //4
            graph.Add(2);  //5
            graph.Add(9);  //6
            graph.Add(10); //7

            graph.AttachDirectedEdge(0, 3);
            graph.AttachDirectedEdge(0, 4);
            graph.AttachDirectedEdge(1, 3);
            graph.AttachDirectedEdge(2, 4);
            graph.AttachDirectedEdge(2, 7);
            graph.AttachDirectedEdge(3, 5);
            graph.AttachDirectedEdge(3, 6);
            graph.AttachDirectedEdge(3, 7);
            graph.AttachDirectedEdge(4, 6);

            List<int> result = new List<int>();

            Assert.IsTrue(graph.TopologicalSort(result));

            result.Reverse();

            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(7, result[1]);
            Assert.AreEqual(11, result[2]);
            Assert.AreEqual(3, result[3]);
            Assert.AreEqual(10, result[4]);
            Assert.AreEqual(8, result[5]);
            Assert.AreEqual(9, result[6]);
            Assert.AreEqual(2, result[7]);
        }

        [TestMethod]
        public void BFS()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            bool result = graph.BreadthFirstSearch(0, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BFS2()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(3, 1);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            bool result = graph.BreadthFirstSearch(5, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DFS()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            bool result = graph.DepthFirstSearch(0, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DFS2()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(3, 1);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            bool result = graph.DepthFirstSearch(5, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinimalSpanningTree()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            string result = graph.MinimalSpanningTree();
            Assert.AreEqual("A:C C:F A:D ", result);
        }

        [TestMethod]
        public void MinimalSpanningTree2()
        {
            Graph<char> graph = new Graph<char>(6);

            graph.Add('A');
            graph.Add('B');
            graph.Add('C');
            graph.Add('D');
            graph.Add('E');
            graph.Add('F');

            graph.AttachEdge(0, 2);
            graph.AttachEdge(0, 3);
            graph.AttachEdge(3, 1);
            graph.AttachEdge(1, 4);
            graph.AttachEdge(2, 5);


            string result = graph.MinimalSpanningTree();
            Assert.AreEqual("A:C C:F A:D D:B B:E ", result);
        }
    }
}
