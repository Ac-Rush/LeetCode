using System.Collections.Generic;

namespace Leetcode.Stack
{
    class Valid_Parentheses
    {
        
        public bool IsValid(string s)
        {

            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                    stack.Push(')');  //这个 反向放 太棒了 太赞了
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count ==0 || stack.Pop() != c)
                    return false;
            }
            return stack.Count == 0;
        }
    }
}
