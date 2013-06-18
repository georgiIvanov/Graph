using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraph
{
    class EdgeInfo : IComparable<EdgeInfo>
    {
        int vertex1, vertex2;
        int weight;

        public EdgeInfo(int vertex1, int vertex2, int weight)
        {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
            this.Weight = weight;
        }

        public static bool operator ==(EdgeInfo edge1, EdgeInfo edge2)
        {
            return edge1.vertex2 == edge2.vertex2;
        }

        public static bool operator !=(EdgeInfo edge1, EdgeInfo edge2)
        {
            return edge1.vertex2 != edge2.vertex2;
        }

        public static bool operator <(EdgeInfo edge1, EdgeInfo edge2)
        {
            return edge1.weight < edge2.weight;
        }

        public static bool operator >(EdgeInfo edge1, EdgeInfo edge2)
        {
            return edge1.weight > edge2.weight;
        }

        public int CompareTo(EdgeInfo otherEdge)
        {
            return this.Weight.CompareTo(otherEdge.Weight);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public int Vertex1
        {
            get
            {
                return this.vertex1;
            }
            set
            {
                this.vertex1 = value;
            }
        }

        public int Vertex2
        {
            get
            {
                return this.vertex2;
            }
            set
            {
                this.vertex2 = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

    }
}
