using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Next_Greater_Element_I
    {
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            var map = new Dictionary<int,int>(); // map from x to next greater element of x
            var stack = new Stack<int>();
            foreach (int num in nums)
            {
                while (stack.Count > 0 && stack.Peek() < num)
                    map[stack.Pop()] = num;
                stack.Push(num);
            }
            for (int i = 0; i < findNums.Length; i++)
                if (map.ContainsKey(findNums[i]))
                {
                    findNums[i] = map[findNums[i]];
                }
                else
                {
                    findNums[i] =-1;
                }
            return findNums;
        }
    }
}
