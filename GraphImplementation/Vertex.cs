using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Vertex<T>
    {
        T node;

        public Vertex(T node)
        {
            this.Node = node;
        }

        public T Node
        {
            get
            {
                return this.node;
            }

            private set
            {
                this.node = value;
            }
        }
    }
}
