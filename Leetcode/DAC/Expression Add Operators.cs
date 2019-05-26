using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DAC
{
    class Expression_Add_Operators
    {
        /*
         *This problem has a lot of edge cases to be considered:

overflow: we use a long type once it is larger than Integer.MAX_VALUE or minimum, we get over it.
0 sequence: because we can't have numbers with multiple digits started with zero, we have to deal with it too.
a little trick is that we should save the value that is to be multiplied in the next recursion.
         *
         */
        public IList<string> AddOperators(string num, int target)
        {
            List<string> rst = new List<string>();
            if (num == null || num.Length == 0) return rst;
            helper(rst, "", num, target, 0, 0, 0);
            return rst;
        }

        // eval是 path当前的 结果， multed是用来保存 如果需要乘的结果
        public void helper(List<string> rst, string path, string num, int target, int pos, long eval, long multed)
        {
            if (pos == num.Length) //   如果结束了
            {
                if (target == eval)  // 如果找到了 结果 就加进去
                    rst.Add(path);
                return;
            }
            for (int i = pos; i < num.Length; i++) //从当前节点遍历后面的数
            {
                // 如果 pos的是0 要单独处理，e.g. 05  5 和 05 取出 cur的结果一样
                if (i != pos && num[pos] == '0') break; //multiple digits started with zero, we have to deal with it too
                long cur = long.Parse(num.Substring(pos, i - pos + 1)); 
                if (pos == 0)
                {
                    helper(rst, path + cur, num, target, i + 1, cur, cur);
                }
                else
                {
                    helper(rst, path + "+" + cur, num, target, i + 1, eval + cur, cur);

                    helper(rst, path + "-" + cur, num, target, i + 1, eval - cur, -cur);

                    helper(rst, path + "*" + cur, num, target, i + 1, eval - multed + multed * cur, multed * cur);  //这个真得想想
                }
            }
        }
    }
}
