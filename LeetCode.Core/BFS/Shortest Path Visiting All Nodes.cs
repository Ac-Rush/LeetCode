using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    public class Shortest_Path_Visiting_All_Nodes
    {
        public class State
        {  //head ，当前的节点，  cover用二进制表示 每个点是否访问过了，
            public int cover, head;
            public State(int c, int h)
            {
                cover = c;
                head = h;
            }
        }
        public int ShortestPathLength(int[][] graph)
        {
            int N = graph.Length;
            Queue<State> queue = new Queue<State>();
            int[,] dist = new int[1 << N,N]; 
            for(int i = 0; i < dist.GetLength(0); i ++)
            {
                for (int j = 0; j < dist.GetLength(1); j++)
                {
                    dist[i, j] = N*N;
                }
            }

            for (int x = 0; x < N; ++x)  //每个节点都有可能出发，把所有节点都放进 queue
            {
                queue.Enqueue(new State(1 << x, x));
                dist[1 << x,x] = 0;
            }

            while (queue.Any())
            {
                State node = queue.Dequeue();
                int d = dist[node.cover,node.head];
                if (node.cover == (1 << N) - 1) return d;

                foreach (int child in graph[node.head])
                {
                    int cover2 = node.cover | (1 << child);
                    if (d + 1 < dist[cover2,child]) //这样可以去重， 不停优化
                    {
                        dist[cover2,child] = d + 1;
                        queue.Enqueue(new State(cover2, child));
                    }
                }
            }

            return -1;
        }
    }
}
