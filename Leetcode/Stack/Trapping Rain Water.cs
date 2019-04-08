using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Trapping_Rain_Water
    {
        /// <summary>
        /// my solution 
        /// 1: 从左往右 扫一遍 记录点i, 左边最高的值，
        /// 2: 从右往左 扫一遍， 记录点i,右边最高的值。
        /// 3. 从左往右， 算出当前点最多盛的水， 
        /// 
        /// time O(N)
        /// space O(N)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            var n = height.Length;
            var maxLeft = new int[n];
            var maxRight = new int[n];

            var maxLeftV = 0;
            for (int i = 0; i < n; i++)
            {
                maxLeft[i] = maxLeftV;
                maxLeftV = Math.Max(maxLeftV, height[i]);
            }
            var maxRigthV = 0;
            for (int i = n -1; i >= 0; i--)
            {
                maxRight[i] = maxRigthV;
                maxRigthV = Math.Max(maxRigthV, height[i]);
            }
            var sum = 0;
            for (int i = 1; i < n-1; i++)
            {
                var curt = Math.Min(maxLeft[i], maxRight[i]) - height[i];
                if (curt > 0)
                {
                    sum += curt;
                }
            }
            return sum;
        }
    }


    class Trapping_Rain_Water_TWO_Pointer
    {
        /// <summary>
        /// 左边一个指针右边一个指针，
        /// 
        /// 这个空间是O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int ans = 0;
            int left_max = 0, right_max = 0;
            while (left < right)
            {
                //高的柱子用来挡水， 所以先动低的柱子
                if (height[left] < height[right]) //如果右边的点高，
                {
                   //如果左边的点 大于左边最大的，更新左边的点， 
                   //否则就可以积水，  因为 这个点小于 左边最大的和右边的点
                    var i = height[left] >= left_max ? (left_max = height[left]) : ans += (left_max - height[left]); //max_rigth 不可能小于max_left， 因为如果小于了，那么 curt left 就是max_left， 不会是之前的left
                    //移动左边的点
                    ++left;
                }
                else
                {
                    var i = height[right] >= right_max ? (right_max = height[right]) : ans += (right_max - height[right]);
                    --right;
                }
            }
            return ans;
        }
    }

    public  class Trapping_Rain_Water_Stack
    {
        /// <summary>
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int ans = 0, current = 0;
            Stack<int> st = new Stack<int>();
            while (current < height.Length)
            {
                while (st.Any() && height[current] > height[st.Peek()])
                {
                    int top = st.Peek();
                    st.Pop();
                    if (st.Count ==0)
                        break;
                    int distance = current - st.Peek() - 1;
                    int bounded_height = Math.Min(height[current], height[st.Peek()]) - height[top];
                    ans += distance * bounded_height;
                }
                st.Push(current++);
            }
            return ans;
        }
    }
}
