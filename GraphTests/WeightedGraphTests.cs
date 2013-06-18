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
    }
}
