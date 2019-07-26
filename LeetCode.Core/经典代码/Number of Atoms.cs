using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    public class Number_of_Atoms
    {
        /// <summary>
        /// 经典题 字符串的处理， 栈
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public static string CountOfAtoms(string formula)
        {
            int N = formula.Length;
            Stack<Dictionary<string, int>> stack = new Stack<Dictionary<string, int>>();
            stack.Push(new Dictionary<string, int>());

            for (int i = 0; i < N;)
            {
                if (formula[i] == '(')
                {
                    stack.Push(new Dictionary<string, int>());
                    i++;
                }
                else if (formula[i] == ')')
                {
                    var top = stack.Pop();
                    int iStart = ++i, multiplicity = 1;
                    while (i < N && char.IsDigit(formula[i])) i++;
                    if (i > iStart) multiplicity = int.Parse(formula.Substring(iStart, i - iStart ));
                    foreach (String c in top.Keys)
                    {
                        if (!stack.Peek().ContainsKey(c))
                        {
                            stack.Peek()[c] = 0; 
                        }
                        stack.Peek()[c] += top[c]*multiplicity;
                    }
                }
                else
                {
                    int iStart = i++;
                    while (i < N && char.IsLower(formula[i])) i++;
                    String name = formula.Substring(iStart, i - iStart );
                    iStart = i;
                    while (i < N && char.IsDigit(formula[i])) i++;
                    int multiplicity = i > iStart ? int.Parse(formula.Substring(iStart, i - iStart )) : 1;
                    if (!stack.Peek().ContainsKey(name))
                    {
                        stack.Peek()[name] = 0;
                    }
                    stack.Peek()[name] += multiplicity;
                }
            }

            StringBuilder ans = new StringBuilder();
            foreach (String name in stack.Peek().Keys.OrderBy( key =>key))
            {
                ans.Append(name);
                int multiplicity = stack.Peek()[name];
                if (multiplicity > 1) ans.Append("" + multiplicity);
            }
            return ans.ToString();
        }



    }
}
