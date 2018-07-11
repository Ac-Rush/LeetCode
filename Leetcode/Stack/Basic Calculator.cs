using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Basic_Calculator
    {
        public int Calculate(string s)
        {
            var nums = new Stack<int>();
            int result = 0;
            int number = 0;
            int sign = 1;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    number = 10 * number + (int)(c - '0');
                }
                else if (c == '+')
                {
                    result += sign * number;
                    number = 0;
                    sign = 1;
                }
                else if (c == '-')
                {
                    result += sign * number;
                    number = 0;
                    sign = -1;
                }
                else if (c == '(')
                {
                    //we push the result first, then sign;
                    nums.Push(result);
                    nums.Push(sign);
                    //reset the sign and result for the value in the parenthesis
                    sign = 1;
                    result = 0;
                }
                else if (c == ')')
                {
                    result += sign * number;
                    number = 0;
                    result *= nums.Pop();    //stack.pop() is the sign before the parenthesis
                    result += nums.Pop();   //stack.pop() now is the result calculated before the parenthesis

                }
            }
            if (number != 0) result += sign * number;
            return result;
        }
    }


    class Basic_Calculator_2
    {
        public int Calculate(string s)
        {
            //sign 正负号
            int len = s.Length, sign = 1, result = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    int sum = s[i] - '0';
                    while (i + 1 < len && char.IsDigit(s[i + 1]))
                    {
                        sum = sum * 10 + s[i + 1] - '0';
                        i++;
                    }
                    result += sum * sign;
                }
                else if (s[i] == '+')
                    sign = 1;
                else if (s[i] == '-')
                    sign = -1;
                else if (s[i] == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {                //第一个pop是口号前的 符号   //第二个 pop是 （）之前的结果
                    result = result * stack.Pop() + stack.Pop();
                }

            }
            return result;
        }
    }
}
