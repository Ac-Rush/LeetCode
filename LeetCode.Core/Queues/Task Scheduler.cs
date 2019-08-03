using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Queues
{
    class Task_Scheduler
    {
        /// <summary>
        /// 贪心  填空槽的问题
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            var count = new int[26];
            foreach (var t in tasks)
            {
                count[t - 'A']++;
            }
            System.Array.Sort(count);
            int max_val = count[25] - 1 /*这里要加一*/, idle_slots = max_val * n;  //空槽个数  加上最高的 一行就是 n+1，与下一个相同的间隔 n
            for (int i = 24; i >= 0 && count[i] > 0; i--)
            {
                idle_slots -= Math.Min(count[i], max_val);
            }
            return idle_slots > 0 ? idle_slots + tasks.Length : tasks.Length;
        }
    }
}
