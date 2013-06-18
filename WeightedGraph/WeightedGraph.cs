using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace WeightedGraph
{
    public class WeightedGraph<T> : Graph<T>
    {
        public WeightedGraph(int verticesCount)
            : base(verticesCount)
        {

        }

        public void AttachDirectedEdge(int v1Index, int v2Index, int weight)
        {
            adjacencyMatrix[v1Index, v2Index] = weight;
        }

        public void AttachEdge(int v1Index, int v2Index, int weight)
        {
            adjacencyMatrix[v1Index, v2Index] = weight;
            adjacencyMatrix[v2Index, v1Index] = weight;
        }

        public override string MinimalSpanningTree()
        {
            StringBuilder result = new StringBuilder();

            int currentVert = 0, totalChecked = 0;
            int size = vertices.Count;

            List<EdgeInfo> edges = new List<EdgeInfo>();

            while (totalChecked < size - 1)
            {
                verticesVisits[currentVert] = 1;
                totalChecked++;

                for (int i = 0; i < size; i++)
                {
                    if (i == currentVert || verticesVisits[i] == 1 ||
                        adjacencyMatrix[currentVert, i] == 0)
                    {
                        continue;
                    }

                    EdgeInfo edge = new EdgeInfo(currentVert, i, adjacencyMatrix[currentVert, i]);

                    int foundIndex = edges.FindIndex((x) => x.Weight == edge.Weight);
                    EdgeInfo foundEdge = new EdgeInfo(0,0,0);
                    if(foundIndex >= 0)
                    {
                        foundEdge = edges[foundIndex];
                    }

                    if (edges.Count == 0 || foundIndex < 0)
                    {
                        edges.Add(edge);
                    }
                    else
                    {
                        if (edge.Weight <= foundEdge.Weight)
                        {
                            foundEdge.Vertex1 = edge.Vertex1;
                            foundEdge.Vertex2 = edge.Vertex2;
                            foundEdge.Weight = edge.Weight;
                        }
                    }
                }

                if (edges.Count == 0)
                {
                    return "Graph not connected";
                }

                edges.Sort();
                edges.Reverse();

                int lastIndex = edges.Count - 1;
                int ver1 = edges[lastIndex].Vertex1;
                currentVert = edges[lastIndex].Vertex2;

                result.AppendFormat("{0}:{1} ", vertices[ver1].Node, vertices[currentVert].Node);

                edges.RemoveAt(lastIndex);
            }

            ClearVerticesVisits();

            return result.ToString();
        }
    }
}
