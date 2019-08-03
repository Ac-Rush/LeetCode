using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    /// <summary>
    /// 这个是教科书上的模板
    /// </summary>
    class Basic_Calculator_III
    {
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            Stack<int> nums = new Stack<int>(); // the stack that stores numbers
            Stack<char> ops = new Stack<char>(); // the stack that stores operators (including parentheses)
          //  int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == ' ') continue;
                if (char.IsDigit(c))  // 用 while 来获取整个 num 加入到 num stack里
                {
                    int num = c - '0';
                    // iteratively calculate each number
                    while (i < s.Length - 1 && char.IsDigit(s[i + 1]))
                    {
                        num = num * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    nums.Push(num);
                    num = 0; // reset the number to 0 before next calculation
                }
                else if (c == '(')  //如果是 左括号，入符号栈
                {
                    ops.Push(c);
                }
                else if (c == ')') //如果是右括号， 那么就要把括号里面的算完， 放入 num
                {
                    // do the math when we encounter a ')' until '('
                    while (ops.Peek() != '(') nums.Push(operation(ops.Pop(), nums.Pop(), nums.Pop()));
                    ops.Pop(); // get rid of '(' in the ops stack
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    //之前是while,我觉得 如此的矩阵 if也可以
                    if (ops.Any() && precedence(c, ops.Peek())) nums.Push(operation(ops.Pop(), nums.Pop(), nums.Pop()));  //如果符号站不空， 并且前面的优先级高
                    ops.Push(c);
                }
            }
            while (ops.Any())
            {
                nums.Push(operation(ops.Pop(), nums.Pop(), nums.Pop()));
            }
            return nums.Pop();
        }

        private static int operation(char op, int b, int a)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b; // assume b is not 0
            }
            return 0;
        }
        // helper function to check precedence of current operator and the uppermost operator in the ops stack 
        //这个就是优先级矩阵
        private static bool precedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')') return false;
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-')) return false;
            return true;
        }
    }
}
