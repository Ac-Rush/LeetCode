using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
   public class Daily_Temperatures
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public static int[] DailyTemperatures(int[] temperatures)
        {

            var result = new int[temperatures.Length];
            for (int i = temperatures.Length - 2; i >= 0; i--)
            {
                if (temperatures[i] < temperatures[i + 1])
                {
                    result[i] = 1; //my bug, was temperatures[i] = 1;
                }
                else
                {
                    var j = i+1;
                    while (temperatures[i] >= temperatures[j] && result[j] !=0) // bug : was while (temperatures[i] > temperatures[j] && result[j] !=0)
                    {
                        j += result[j];
                    }
                    if (temperatures[i] < temperatures[j])
                    {
                        result[i] = j - i;
                    }
                    else
                    {
                        result[i] = 0;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// stack
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public int[] dailyTemperatures2(int[] T)
        {
            int[] ans = new int[T.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = T.Length - 1; i >= 0; --i)
            {
                while (stack.Count >0 && T[i] >= T[stack.Peek()]) stack.Pop();
                ans[i] = stack.Count ==0 ? 0 : stack.Peek() - i;
                stack.Push(i);
            }
            return ans;
        }
    }
}
