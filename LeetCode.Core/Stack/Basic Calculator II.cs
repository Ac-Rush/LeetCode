using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Basic_Calculator_II
    {
        /// <summary>
        /// 这个做法不错啊，  这个做法 就是 初始化 是 +
        /// 如果之前的是+  ,  那么  push +num
        /// 如果之前是 -  ,  那么 push  -num
        /// 如果之前是  * 那么 push  pop*num
        /// 如果之前是 / 那么 push pop/num
        /// 
        /// 更新 sign
        /// ans 就是 stack.Sum
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            int len;
            if (s == null || (len = s.Length) == 0) return 0;
            Stack<int> stack = new Stack<int>();
            int num = 0;
            char sign = '+';
            for (int i = 0; i < len; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                if ((!char.IsDigit(s[i]) && ' ' != s[i]) || i == len - 1)
                {
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    if (sign == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    if (sign == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }
                    sign = s[i];
                    num = 0;
                }
            }

            int re = 0;
            foreach (int i in stack)
            {
                re += i;
            }
            return re;
        }
    }
}
