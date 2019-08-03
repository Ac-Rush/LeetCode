using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    /// <summary>
    /// Approach #1: Subtree Sum and Count [Accepted]
    /// 因为这个是个树状结构
    /// 
    /// </summary>
    /// 
    /*
     * 思路：直接BFS会TLE，优化degree为1的Node也TLE，接着想优化其他degree的Node，到此有点卡住

答案是建树，然后求出每个Node有多个子Node，这样只要求出res[root]，求root的child的时候，就知道有count[child]个Node的距离拉近了，N-count[i]个Node的距离变远 了1，这样只要以原始root为起点做一遍BFS/DFS就可以了
     count[node] :节点个数和
     stsum[node], 节点数值和
        Root the tree. For each node, consider the subtree of that node plus all descendants,
        and consider count[node] and stsum[node], the number of nodes and the sum of the value of those nodes.

We can calculate this using a post-order traversal, where on exiting some node,
the count and stsum of all descendants of this node is correct, and we now calculate count[node] += count[child] and stsum[node] += stsum[child] + count[child].
    */

    class Sum_of_Distances_in_Tree
    {
        int[] ans, count;
        List<HashSet<int>> graph;
        int N;
        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            this.N = N;
            graph = new List<HashSet<int>>();
            ans = new int[N];
            count = new int[N];  //树节点和
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 1;  //初始化为1 
            }

            for (int i = 0; i < N; ++i)   //构建图
                graph.Add(new HashSet<int>());
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            dfs(0, -1);
            dfs2(0, -1);
            return ans;
        }

        /*
  count[node] :节点个数和
  stsum[node], 节点数值和
     Root the tree. For each node, consider the subtree of that node plus all descendants,
     and consider count[node] and stsum[node], the number of nodes and the sum of the value of those nodes.

We can calculate this using a post-order traversal, where on exiting some node,
the count and stsum of all descendants of this node is correct, and we now calculate count[node] += count[child] and stsum[node] += stsum[child] + count[child].
 */
        //后序遍历 ，统计节点个数
        //最终 ans[root] 是对的，最终的答案，  其他都是 dfs2去处理
        //这步的 ans[root]是 到所有子树节点的 距离和
        public void dfs(int node, int parent)
        {
            foreach (int child in graph[node])
                if (child != parent)
                {
                    dfs(child, node);
                    count[node] += count[child];
                    ans[node] += ans[child] + count[child];  //这个就是子树的距离， 父节点就需要对每个子树节点都加1
                }
        }

        /*
         * 
       Now for the insight: if we have a node parent and it's child child, then ans[child] = ans[parent] - count[child] + (N - count[child]).
       This is because there are count[child] nodes that are 1 easier to get to from child than parent, and N-count[child] nodes that are 1 harder to get to from child than parent. 
       然后求出每个Node有多个子Node，这样只要求出res[root]，求root的child的时候，就知道有count[child]个Node的距离拉近了，N-count[i]个Node的距离变远 了1，这样只要以原始root为起点做一遍BFS/DFS就可以了
     */
        public void dfs2(int node, int parent)
        {
            foreach (int child in graph[node])
                if (child != parent)
                {
                    //1. 这个太妙了， 就是 里自己子树的节点都变近了1  所以 - count[child]
                    //2 理 剩下节点都远 了1  ， 所以+ （N - count[child]）
                    ans[child] = ans[node] - count[child] + N - count[child];
                    dfs2(child, node);
                }
        }
    }
}
