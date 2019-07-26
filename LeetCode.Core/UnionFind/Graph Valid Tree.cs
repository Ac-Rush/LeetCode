using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.UnionFind
{
    class Graph_Valid_Tree
    {
        int[] parent;
        public bool ValidTree(int n, int[,] edges)
        {
            int edgeCount = edges.GetLength(0);
            //An undirected tree with n nodes must have exactly n−1 edges.
            if (edgeCount != n - 1)
                return false;
            //Initializing parent to -1 for all vertices.
            this.parent = new int[n];
            for (int i = 0; i < n; i++)
                this.parent[i] = i;
            for (int i = 0; i < edgeCount; i++)
            {
                //Extracting vertices of an edge.
                int elementOne = edges[i, 0];
                int elementTwo = edges[i, 1];
                //Find
                int parentOne = Find(elementOne);
                int parentTwo = Find(elementTwo);
                if (parentOne == parentTwo)
                    return false;
                else
                    this.parent[parentOne] = parentTwo;     //Union
            }
            return true;
        }
        private int Find(int element)
        {
            if (element != parent[element])
            {
                parent[element] = Find(parent[element]);
            }
            return parent[element];
        }
    }
}
