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


        /// <summary>
        ///  我自己的答案，一遍过，
        /// Stack 就可以用于找 右边第一大的或是小的
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public int[] dailyTemperaturesMY(int[] T)
        {
            var n = T.Length;
            var ans = new int[n];
            var s = new Stack<int>(); // [index] //存的是 index而不是值，
            for (int i = 0; i < n;)
            {
                if (s.Count == 0 || T[i] <= T[s.Peek()])
                {
                    // 如果 stack 空 或是， 当前温度更低， 入栈， 
                    s.Push(i++);  //并且 处理下一个数
                }
                else
                {
                    //反之，就可以得到 比栈顶元素 温度高的第一个元素， 
                    var lower = s.Pop();
                    ans[lower] = i - lower; // 保存结果， 
                    //特别注意，这边不用i++，不用这里写loop， 借助外面的 loop就能代替这里的 loop
                }
            }
            return ans;
        }
    }
}
