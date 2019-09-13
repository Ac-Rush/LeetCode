﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.DAC.Count_of_Smaller_Numbers_After_Self_BST;

namespace Leetcode.模板
{
    class BFSTemplete
    {
        private int V;   // No. of vertices 
        private List<int>[] adj; //Adjacency Lists 

        /// <summary>
        /// 用 BFS 求最短或最长距离
        /// </summary>
        /// <param name="s"></param>
        int BFS_Len(int s)
        {
            var Len = 0;
            // Mark all the vertices as not visited(By default 
            // set as false) 
            bool[] visited = new bool[V];

            // Create a queue for BFS 
            var queue = new Queue<int>();

            // Mark the current node as visited and enqueue it 
            visited[s] = true;
            queue.Enqueue(s);


            while (queue.Count > 0)
            {
                var count = queue.Count;
                while (count-- > 0)
                {
                    // Dequeue a vertex from queue and print it 
                    s = queue.Dequeue();
                    // Get all adjacent vertices of the dequeued vertex s 
                    // If a adjacent has not been visited, then mark it 
                    // visited and enqueue it 
                    foreach (var n in adj[s])
                    {
                        if (!visited[n])
                        {
                            visited[n] = true;
                            queue.Enqueue(n);
                        }
                    }
                }

                Len++;
            }

            return Len;
        }


        void BFS(int s)
        {
            // Mark all the vertices as not visited(By default 
            // set as false) 
            bool[] visited = new bool[V];

            // Create a queue for BFS 
            var queue = new Queue<int>();

            // Mark the current node as visited and enqueue it 
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count > 0)
            {
                // Dequeue a vertex from queue and print it 
                s = queue.Dequeue();
                Console.WriteLine(s);

                // Get all adjacent vertices of the dequeued vertex s 
                // If a adjacent has not been visited, then mark it 
                // visited and enqueue it 
                foreach (var n in adj[s])
                {
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

        int BFS(Node root, Node target)
        {
            Queue<Node> queue = new Queue<Node>();  // store all nodes which are waiting to be processed
            int step = 0;       // number of steps neeeded from root to current node
                                // initialize
            queue.Enqueue(root);
            //add root to queue;
            // BFS
            /*
             while (queue is not empty) {
            {
                step = step + 1;
                // iterate the nodes which are already in the queue
                int size = queue.size();
                // 遍历一行
                for (int i = 0; i < size; ++i)
                {
                    Node cur = the first node in queue;
                    return step if cur is target;
                    for (Node next : the neighbors of cur)
                    {
                        add next to queue;
                    }
                    remove the first node from queue;
                }
            }
            */
            return -1;          // there is no path from root to target
        }

        int BFS2(Node root, Node target)
        {
            Queue<Node> queue;  // store all nodes which are waiting to be processed
            /*
            Set<Node> visited;  // store all the nodes that we've visited
            int step = 0;       // number of steps neeeded from root to current node
            // initialize
            add root to queue;
            add root to visited;
            // BFS
            while (queue is not empty)
            {
                step = step + 1;
                // iterate the nodes which are already in the queue
                int size = queue.size();
                for (int i = 0; i < size; ++i)
                {
                    Node cur = the first node in queue;
                    return step if cur is target;
                    for (Node next : the neighbors of cur)
                    {
                        if (next is not in used) { //   就是多了这句  去重用 
                            add next to queue;
                            add next to visited;
                        }
                        remove the first node from queue;
                    }
                }
            }
            */
            return -1;          // there is no path from root to target
        }
    }
}
