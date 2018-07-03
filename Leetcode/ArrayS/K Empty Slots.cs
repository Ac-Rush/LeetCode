using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    /// <summary>
    ///The idea is to use an array days[] to record each position's flower's blooming day. That means days[i] is the blooming day of the flower in position i+1. We just need to find a subarray days[left, left+1,..., left+k-1, right] which satisfies: for any i = left+1,..., left+k-1, we can have days[left] < days[i] && days[right] < days[i]. Then, the result is max(days[left], days[right])
    /// </summary>
    class K_Empty_Slots
    {
        public int KEmptySlots(int[] flowers, int k)
        {
            int[] days = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++) days[flowers[i] - 1] = i + 1;// 位置在 flowers[i] - 1 第 i+1天开花
            int left = 0, right = k + 1, res = int.MaxValue;
            for (int i = 0; right < days.Length; i++)
            {
                if (days[i] < days[left] || days[i] <= days[right])
                {
                    if (i == right) res = Math.Min(res, Math.Max(days[left], days[right]));   //we get a valid subarray
                    left = i;   //更新 left, right
                    right = k + 1 + i;
                }
                // else 就是 i++ 这边是 validate 
            }
            return (res == int.MaxValue) ? -1 : res;
        }
    }
}
