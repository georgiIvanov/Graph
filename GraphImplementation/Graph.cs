using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph<T>
    {
        protected List<Vertex<T>> vertices;
        protected int maxVerts;
        protected int[,] adjacencyMatrix;
        protected int[] verticesVisits;

        public Graph(int verticesCount)
        {
            maxVerts = verticesCount;
            vertices = new List<Vertex<T>>(verticesCount);
            adjacencyMatrix = new int[verticesCount, verticesCount];
            verticesVisits = new int[verticesCount];
        }

        public bool Add(T node)
        {
            if (vertices.Count >= maxVerts)
            {
                return false;
            }

            vertices.Add(new Vertex<T>(node));
            return true;
        }

        public void AttachEdge(int v1Index, int v2Index)
        {
            adjacencyMatrix[v1Index, v2Index] = 1;
            adjacencyMatrix[v2Index, v1Index] = 1;
        }

        public void AttachDirectedEdge(int v1Index, int v2Index)
        {
            adjacencyMatrix[v1Index, v2Index] = 1;
        }

        int GetNextUnvisitedVertex(int index)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (adjacencyMatrix[index, i] == 1 &&
                    verticesVisits[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private int GetVertNoSuccessor(int[,] adjMatrix, int size)
        {
            bool edgeFound = false;
            for (int row = 0; row < size; row++)
            {
                edgeFound = false;
                for (int col = 0; col < size; col++)
                {
                    if (adjMatrix[row, col] != 0)
                    {
                        edgeFound = true;
                        break;
                    }
                }
                if (edgeFound == false)
                {
                    return row;
                }
            }

            return -1;
        }

        public bool DepthFirstSearch(int startIndex, int endIndex)
        {
            verticesVisits[startIndex] = 1;

            // uncomment to see visited nodes
            // Console.Write("{0} ", vertices[startIndex].Node);

            Stack<int> searchStack = new Stack<int>();
            int currentVert = 0;
            searchStack.Push(startIndex);

            while (searchStack.Count != 0)
            {
                currentVert = GetNextUnvisitedVertex(searchStack.Peek());

                if (currentVert == -1)
                {
                    searchStack.Pop();
                }
                else
                {
                    verticesVisits[currentVert] = 1;
                    searchStack.Push(currentVert);
                    // uncomment to see visited nodes
                    // Console.Write("{0} ", vertices[currentVert].Node);
                }

                if (currentVert == endIndex)
                {
                    ClearVerticesVisits();
                    return true;
                }
            }

            ClearVerticesVisits();
            return false;
        }

        public bool BreadthFirstSearch(int startIndex, int endIndex)
        {
            verticesVisits[startIndex] = 1;
            // uncomment to see visited nodes
            // Console.Write("{0} ", vertices[startIndex].Node);

            Queue<int> searchQueue = new Queue<int>();
            int currentVert = 0;
            int nextForSearch = 0;

            searchQueue.Enqueue(startIndex);

            while (searchQueue.Count != 0)
            {
                currentVert = searchQueue.Dequeue();

                if (currentVert == endIndex)
                {
                    ClearVerticesVisits();
                    return true;
                }

                while ((nextForSearch = GetNextUnvisitedVertex(currentVert)) != -1)
                {
                    verticesVisits[nextForSearch] = 1;
                    searchQueue.Enqueue(nextForSearch);
                    // uncomment to see visited nodes
                    // Console.Write("{0} ", vertices[nextForSearch].Node);
                }
            }

            ClearVerticesVisits();
            return false;
        }

        public virtual string MinimalSpanningTree()
        {
            StringBuilder result = new StringBuilder();
            int startIndex = 0;
            verticesVisits[startIndex] = 1;

            Stack<int> searchStack = new Stack<int>();
            int vert = 0;
            int currentVert = 0;

            searchStack.Push(startIndex);

            while (searchStack.Count != 0)
            {
                currentVert = searchStack.Peek();
                vert = GetNextUnvisitedVertex(currentVert);

                if (vert == -1)
                {
                    searchStack.Pop();
                }
                else
                {
                    verticesVisits[vert] = 1;
                    searchStack.Push(vert);

                    result.AppendFormat("{0}:{1} ", vertices[currentVert].Node,
                        vertices[vert].Node);
                }
            }

            ClearVerticesVisits();

            return result.ToString();
        }

        
        public bool TopologicalSort(List<T> output)
        {
            bool hasCycles = false;
            List<Vertex<T>> tempVerts = new List<Vertex<T>>(vertices);
            int tempSize = tempVerts.Count;

            int[,] tempAdjMatrix = new int[maxVerts, maxVerts];

            for (int i = 0; i < maxVerts; i++)
            {
                for (int j = 0; j < maxVerts; j++)
                {
                    tempAdjMatrix[i, j] = adjacencyMatrix[i, j];
                }
            }

            while (tempSize > 0)
            {
                int v = GetVertNoSuccessor(tempAdjMatrix, tempSize);
                if (v == -1)
                {
                    hasCycles = true;
                    break;
                }
                
                output.Add(tempVerts[v].Node);

                if(v != tempSize -1)
                {
                    tempVerts.RemoveAt(v);

                    for (int row = v; row < tempSize - 1; row++)
			        {
                        for (int col = 0; col < tempSize; col++)
			            {
			                tempAdjMatrix[row, col] = tempAdjMatrix[row + 1, col];
			            }
			        }

                    for (int col = v; col < tempSize - 1; col++)
			        {
                        for (int row = 0; row < tempSize; row++)
			            {
			                tempAdjMatrix[row, col] = tempAdjMatrix[row, col + 1];
			            }
			        }
                }

                tempSize--;
            }

            return !hasCycles;
        }

        protected void ClearVerticesVisits()
        {
            verticesVisits = new int[maxVerts];
        }
    }
}
