using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Clone_Graph
    {
        public class UndirectedGraphNode
        {
            public int label;
            public IList<UndirectedGraphNode> neighbors;

            public UndirectedGraphNode(int x)
            {
                label = x;
                neighbors = new List<UndirectedGraphNode>();
            }
        }
        /// <summary>
        /// 哈哈哈，我的答案一次过
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return node; //my bug 没有 check null， 不过我是知道的
            var dict = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>(); //dict 保存mapping
            var visited = new HashSet<UndirectedGraphNode>(); //visited去重
            var queue = new Queue<UndirectedGraphNode>() ; //queue 用来BFS
            queue.Enqueue(node);
            //先复制点
            while (queue.Any())
            {
                var u = queue.Dequeue();
                visited.Add(u);
                var newU = new UndirectedGraphNode(u.label);
                dict[u] = newU;
                foreach (var neighbor in u.neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            //再复制边
            foreach (var u in dict.Keys)
            {
                foreach (var neighbor in u.neighbors)
                {
                    dict[u].neighbors.Add(dict[neighbor]);
                }
            }
            return dict[node];

        }
    }
}
