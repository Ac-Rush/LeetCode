using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DAC
{
    class Different_Ways_to_Add_Parentheses
    {
        
        public IList<int> DiffWaysToCompute(string input)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' ||
                    input[i] == '*' ||
                    input[i] == '+')
                {
                    var part1 = input.Substring(0, i);
                    var part2 = input.Substring(i + 1);
                    var part1Ret = DiffWaysToCompute(part1);
                    var part2Ret = DiffWaysToCompute(part2);
                    foreach (int p1 in   part1Ret)
                    {
                        foreach (var p2 in   part2Ret)
                        {
                            int c = 0;
                            switch (input[i])
                            {
                                case '+':
                                    c = p1 + p2;
                                    break;
                                case '-':
                                    c = p1 - p2;
                                    break;
                                case '*':
                                    c = p1 * p2;
                                    break;
                            }
                            ret.Add(c);
                        }
                    }
                }
            }
            if (ret.Count == 0)
            {
                ret.Add(Int32.Parse(input));
            }
            return ret;
        }


    }



    /// <summary>
    /// dp solution
    /// </summary>
    class Different_Ways_to_Add_ParenthesesDP
    {

        public IList<int> DiffWaysToCompute(string input)
        {

            var n = input.Length;
            var memo = new IList<int>[n, n];
            return Helper(input.ToCharArray(), 0, n - 1, memo);
        }

        public IList<int> Helper(char[] input, int start , int end, IList<int>[,] memo)
        {
            if (memo[start, end] != null)
            {
                return memo[start, end];
            }
            List<int> ret = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (input[i] == '-' ||
                    input[i] == '*' ||
                    input[i] == '+')
                {
                    var part1Ret = Helper(input, start, i -1, memo);
                    var part2Ret = Helper(input, i+1, end, memo);
                    foreach (int p1 in part1Ret)
                    {
                        foreach (var p2 in part2Ret)
                        {
                            int c = 0;
                            switch (input[i])
                            {
                                case '+':
                                    c = p1 + p2;
                                    break;
                                case '-':
                                    c = p1 - p2;
                                    break;
                                case '*':
                                    c = p1 * p2;
                                    break;
                            }
                            ret.Add(c);
                        }
                    }
                }
            }
            if (ret.Count == 0)
            {
                ret.Add(Int32.Parse(new String(input, start, end - start +1)));
            }
            memo[start, end] = ret;
            return ret;
        }


    }
}
