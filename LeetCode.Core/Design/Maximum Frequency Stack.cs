using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    class FreqStack
    {
        /// <summary>
        /// 
        /// </summary>
        public FreqStack()
        {

        }
        /// <summary>
        /// 一个hash 记录次数
        /// </summary>
        Dictionary<int, int> freq = new Dictionary<int, int>();
        /// <summary>
        /// 一个 hash记录 这个次数的 数的 栈
        /// </summary>
        private Dictionary<int, Stack<int>> m = new Dictionary<int, Stack<int>>();
        int maxfreq = 0;

        public void Push(int x)
        {
            int f = 1;
            if (freq.ContainsKey(x))
            {
                f = freq[x];
            }
            freq[x] = ++f;
            maxfreq = Math.Max(maxfreq, f);
            if (!m.ContainsKey(f)) m[f] =  new Stack<int>();
            m[f].Push(x);
        }

        public int Pop()
        {
            int x = m[maxfreq].Pop();
            freq[x] = maxfreq - 1;
            if (m[maxfreq].Count == 0) maxfreq--;
            return x;
        }
    }
}
