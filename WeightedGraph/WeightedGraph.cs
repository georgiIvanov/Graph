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
        StringBuilder searchResult;

        public WeightedGraph(int verticesCount)
            : base(verticesCount)
        {
            searchResult = new StringBuilder();
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

                edges.Sort((x, y) => x.CompareTo(y));

                int lastIndex = edges.Count - 1;
                int ver1 = edges[lastIndex].Vertex1;
                currentVert = edges[lastIndex].Vertex2;

                searchResult.AppendFormat("{0}:{1} ", vertices[ver1].Node, vertices[currentVert].Node);

                edges.RemoveAt(lastIndex);
            }

            ClearVerticesVisits();

            string result = searchResult.ToString();
            searchResult.Clear();

            return result;
        }

        public string FindShortestPath(int sourceVertex)
        {
            int n = vertices.Count;
            int[] current = new int[n];
            int[] previous = new int[n];
            int[] passed = new int[n];

            InitializeVariablesForSearch(sourceVertex, n, current, previous, passed);

            while (true)
            {
                int j = -1; //index of smallest distance
                int distance = int.MaxValue;

                FindSmallestDistance(n, current, passed, ref j, ref distance);

                if(j == -1)
                {
                    break;
                }

                passed[j] = 0;

                for (int i = 0; i < n; i++)
                {
                    if (passed[i] != 0 && adjacencyMatrix[j, i] != 0)
                    {
                        if (current[i] > current[j] + adjacencyMatrix[j, i])
                        {
                            current[i] = current[j] + adjacencyMatrix[j, i];
                            previous[i] = j;
                        }
                    }
                }
            }

            return PrintResult(sourceVertex, current, previous);
        }

        public string FindShortestPath(int sourceVertex, int targetVertex)
        {
            int targetValue = adjacencyMatrix[sourceVertex, targetVertex];
            int i;
            int n = vertices.Count;
            int[] current = new int[n];
            int[] previous = new int[n];
            int[] passed = new int[n];

            InitializeVariablesForSearch(sourceVertex, n, current, previous, passed);

            while (true)
            {
                int j = -1; //index of smallest distance
                int distance = int.MaxValue;

                FindSmallestDistance(n, current, passed, ref j, ref distance);

                if (distance == targetValue)
                {
                    break;
                }

                if (j == -1)
                {
                    break;
                }

                passed[j] = 0;

                for (i = 0; i < n; i++)
                {
                    if (passed[i] != 0 && adjacencyMatrix[j, i] != 0)
                    {
                        if (current[i] > current[j] + adjacencyMatrix[j, i])
                        {
                            current[i] = current[j] + adjacencyMatrix[j, i];
                            previous[i] = j;
                        }
                    }
                }
            }

            return PrintResultForTarget(sourceVertex, current, previous, targetVertex);
        }

        private static void FindSmallestDistance(int n, int[] current, int[] passed, ref int j, ref int di)
        {
            for (int i = 0; i < n; i++)
            {
                if (passed[i] != 0 && current[i] < di)
                {
                    di = current[i];
                    j = i;
                }
            }
        }

        private void InitializeVariablesForSearch(int sourceVertex, int n, int[] d, int[] pred, int[] V)
        {
            for (int i = 0; i < n; i++)
            {
                if (adjacencyMatrix[sourceVertex, i] == 0)
                {
                    d[i] = int.MaxValue;
                    pred[i] = -1;
                }
                else
                {
                    d[i] = adjacencyMatrix[sourceVertex, i];
                    pred[i] = sourceVertex;
                }
            }

            for (int i = 0; i < n; i++)
            {
                V[i] = 1;
            }
            V[sourceVertex] = 0;
            pred[sourceVertex] = -1;
        }

        void PrintPath(int s, int j, int[] pred)
        {
            if (pred[j] != s)
            {
                PrintPath(s, pred[j], pred);
            }

            searchResult.AppendFormat("{0} ", vertices[j].Node);
        }

        string PrintResult(int s, int[] d, int[] pred)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != s)
                {
                    if (d[i] == int.MaxValue)
                    {
                        searchResult.AppendFormat("No path between vertices {0} and {1}\n", vertices[s].Node, vertices[i].Node);
                    }
                    else
                    {
                        searchResult.AppendFormat("Minimal path between vertices {0} and {1}: {2} ",
                            vertices[s].Node, vertices[i].Node, vertices[s].Node);
                        PrintPath(s, i, pred);
                        searchResult.AppendFormat(", length of path: {0}\n", d[i]);
                    }
                }
            }
            string result = searchResult.ToString();
            searchResult.Clear();
            return result.TrimEnd();
        }

        string PrintResultForTarget(int s, int[] d, int[] pred, int targetVertex)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != s)
                {
                    if(i == targetVertex)
                    {
                        if (d[i] == int.MaxValue)
                        {
                            searchResult.AppendFormat("No path between vertices {0} and {1}\n", 
                                vertices[s].Node, vertices[i].Node);
                            string noResult = searchResult.ToString();
                            searchResult.Clear();
                            return noResult.TrimEnd();
                        }
                        searchResult.AppendFormat("Minimal path between vertices {0} and {1}: {2} ",
                            vertices[s].Node, vertices[i].Node, vertices[s].Node);
                        PrintPath(s, i, pred);
                        searchResult.AppendFormat(", length of path: {0}\n", d[i]);
                        break;
                    }
                }
            }
            string result = searchResult.ToString();
            searchResult.Clear();

            return result.TrimEnd();
        }


    }
}
