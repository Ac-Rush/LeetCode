using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Clone_Graph
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
            }

            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        /// <summary>
        /// 哈哈哈，我的答案一次过
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            if (node == null) return node; //my bug 没有 check null， 不过我是知道的
            var dict = new Dictionary<Node, Node>(); //dict 保存mapping
          //  var visited = new HashSet<Node>(); //visited去重
            var queue = new Queue<Node>() ; //queue 用来BFS
            queue.Enqueue(node);
            //先复制点
            while (queue.Any())
            {
                var u = queue.Dequeue();
            //    visited.Add(u); // 用dict 也可以去重
                var newU = new Node(u.val, new List<Node>());
                dict[u] = newU;
                foreach (var neighbor in u.neighbors)
                {
                    if (!dict.ContainsKey(neighbor)) //mybug 没有去重
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

    public class Clone_Graph2
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
            }

            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        /// <summary>
        /// 居然不要 visited set
        /// </summary>
        private Dictionary<int, Node> map = new Dictionary<int, Node>();
        public Node CloneGraph(Node node)
        {
            return DFS(node);
        }

        private Node DFS(Node node)
        {
            if (node == null) return null;

            if (map.ContainsKey(node.val))
            {
                //不需要 visited数组， 是因为这里 不需要递归了  其实这就是visited数组， 填hash就相当于填set
                return map[node.val];
            }
            var clone = new Node(node.val, new List<Node>());
            map[node.val] = clone;
            foreach (var neighbor in node.neighbors)
            {
                clone.neighbors.Add(DFS(neighbor));
            }
            return clone;
        }
    }


    public class Clone_Graph3
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
            }

            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        /// <summary>
        /// map 就是  visited set 
        /// </summary>
        private Dictionary<int, Node> map = new Dictionary<int, Node>();
        //不是 很好理解，但是可以从 Clone_Graph2 推到过来
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;

            if (map.ContainsKey(node.val))
            {
                //不需要 visited数组， 是因为这里 不需要递归了  其实这就是visited数组， 填hash就相当于填set
                return map[node.val];
            }
            var clone = new Node(node.val, new List<Node>());
            map[node.val] = clone;
            foreach (var neighbor in node.neighbors)
            {
                clone.neighbors.Add(CloneGraph(neighbor));
            }
            return clone;
        }
    }
}
