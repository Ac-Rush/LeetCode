﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    /// <summary>
    /// my solution
    /// </summary>
    class Evaluate_Reverse_Polish_Notation
    {
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0) return 0;
            var stack = new Stack<int>();
            foreach (var token in tokens)
            {
                if (IsOp(token))
                {
                    Calc(stack, token);
                }
                else
                {
                    stack.Push(int.Parse(token));
                }
            }
            return stack.Pop();
        }

        private void Calc(Stack<int> stack, string token)
        {
            var num1 = stack.Pop();
            var num2 = stack.Pop();
            switch (token)
            {
                case "+": stack.Push(num1 + num2); break;
                case "-": stack.Push(num2 - num1); break;
                case "*": stack.Push(num1 * num2); break;
                case "/": stack.Push(num2 /num1); break;
            }
        }

        private bool IsOp(string token)
        {
            if (token.Equals("+") || token.Equals("-")|| token.Equals("*") || token.Equals("/"))
            {
                return true;
            }
            return false;
        }
    }
}
