using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.UnionFind
{
    class Number_of_Connected_Components_in_an_Undirected_Graph
    {

        public int CountComponents(int numNodes, int[,] edges)
        {
            DisjointSet set = new DisjointSet();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                set.Add(edges[i, 0]);
                set.Add(edges[i, 1]);

                if (set.Union(edges[i, 0], edges[i, 1]))
                {
                    numNodes--;
                }
            }

            return numNodes;
        }

        public class DisjointSet
        {
            private Dictionary<int, int> _parents = new Dictionary<int, int>();

            public void Add(int x)
            {
                // Don't add to set if it already is there.
                if (this._parents.ContainsKey(x))
                {
                    return;
                }

                this._parents[x] = x;
            }

            public int GetRoot(int x)
            {
                if (x != this._parents[x])
                {
                    this._parents[x] = GetRoot(this._parents[x]);
                    
                }
                return this._parents[x];
            }

            public bool Union(int x, int y)
            {
                int xRoot = this.GetRoot(x);
                int yRoot = this.GetRoot(y);

                if (xRoot == yRoot)
                {
                    return false;
                }

                this._parents[yRoot] = xRoot;
                return true;
            }
        }
    }
}
