using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.DAC.Count_of_Smaller_Numbers_After_Self_BST;

namespace Leetcode.模板
{
    class DFS_S
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cur">当前位置</param>
        /// <param name="target">目标值</param>
        /// <param name="visited">是否遍历的 set<Node></param>
        /// <returns></returns>
        bool DFS(Node cur, Node target, HashSet<Node> visited)
        {
            /*
            return true if cur is target;
            for (next : each neighbor of cur)
            {
                if (next is not in visited) {
                    add next to visted;
                    return true if DFS(next, target, visited) == true;
                }
            }
        */
            return false;
         }
    }
}
