using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.Stack
{
    class Sum_of_Subarray_Minimums
    {
        /// <summary>
        /// 单调栈 monotone stack .
        /// (1) find the previous less element of each element in a vector with O(n) time:
        /// (2) find the next less element of each element in a vector with O(n) time:
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int SumSubarrayMins(int[] A)
        {
            Stack<int> stack = new Stack<int>();
            // left is for the distance to previous less element
            // right is for the distance to next less element
            int[] left = new int[A.Length], right = new int[A.Length]  ;

            //initialize
            for (int i = 0; i < A.Length; i++) left[i] = i + 1;
            for (int i = 0; i < A.Length; i++) right[i] = A.Length - i;

            for (int i = 0; i < A.Length; i++)
            {
                // for previous less // 找到之前小的
                while (stack.Any() && A[stack.Peek()] > A[i])
                {
                    var x = stack.Pop();
                    right[x] = i - x; // for next less  // 之后小的
                }
                left[i] = !stack.Any() ? i + 1 : i - stack.Peek(); // 找之前小的
                stack.Push(i);
            }
            int ans = 0, mod = 1000000007;
            for(int i = 0; i<A.Length; i++){
                ans = (ans + A[i]*left[i]*right[i])%mod; // 推导公式
            }
            return ans;
        }

        /// <summary>
        /// 或者 优化版本
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int SumSubarrayMins2(int[] A)
        {
            Stack<int> in_stk_p = new Stack<int>(), in_stk_n = new Stack<int>();
            // left is for the distance to previous less element
            // right is for the distance to next less element
            int[] left = new int[A.Length + 1], right = new int[A.Length];



            for (int i = 0; i <= A.Length; i++)
            {
                var value = i == A.Length ? int.MinValue : A[i];
                // for previous less
                while (in_stk_p.Any() && A[in_stk_p.Peek()] > value)
                {

                    var x = in_stk_p.Pop();
                    right[x] = i - x;
                }
                left[i] = !in_stk_p.Any() ? i + 1 : i - in_stk_p.Peek();
                in_stk_p.Push(i);

                // for next less

                in_stk_n.Push(i);
            }

            int ans = 0, mod = 1000000007;
            for (int i = 0; i < A.Length; i++)
            {
                ans = (ans + A[i] * left[i] * right[i]) % mod;
            }
            return ans;
        }
    }
}
