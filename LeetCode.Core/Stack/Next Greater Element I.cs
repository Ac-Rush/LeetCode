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
                while (stack.Count > 0 && stack.Peek() < num)  //求下一个大的 就应该想到栈， 如果最顶端小于当前，  
                    map[stack.Pop()] = num;  //那么 pop最顶端， 并把对应表 存到 map里
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


        public int[] NextGreaterElement2(int[] findNums, int[] nums)
        {
            var map = new Dictionary<int, int>(); // map from x to next greater element of x
            var stack = new Stack<int>();
            foreach (int num in nums)
            {
                while (stack.Count > 0 && stack.Peek() < num)  //求下一个大的 就应该想到栈， 如果最顶端小于当前，  
                    map[stack.Pop()] = num;  //那么 pop最顶端， 并把对应表 存到 map里
                stack.Push(num);
            }
            for (int i = 0; i < findNums.Length; i++)
                if (map.ContainsKey(findNums[i]))
                {
                    findNums[i] = map[findNums[i]];
                }
                else
                {
                    findNums[i] = -1;
                }
            return findNums;
        }
    }

    class Next_Greater_Element_I_2
    {
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            var n = nums.Length;
            var newNums = new int[2 * n];
            for (int i = 0; i < n; i++)
            {
                newNums[i] = nums[i];
                newNums[i + n] = nums[i];
            }
            var result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = int.MinValue;
            }
            var stack = new Stack<int>(); // index 
            for (int i = 0; i < 2 * n; i++)
            {
                if (stack.Peek() > n)
                {
                    break;
                }
                while (stack.Count > 0 && newNums[stack.Peek()] < newNums[i])
                    result[stack.Pop()] = newNums[i];
                stack.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                if (result[i] == int.MinValue)
                {
                    result[i] = -1;
                }
            }
            return result;
        }
    }
}
