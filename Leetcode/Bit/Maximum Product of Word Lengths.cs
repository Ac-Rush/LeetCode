using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Maximum_Product_of_Word_Lengths
    {
        //其实还是个暴力解法， 用 bit 来表示每个char
        public int MaxProduct(string[] words)
        {
            if (words == null || words.Length == 0)
                return 0;
            int len = words.Length;
            int[] value = new int[len];
            for (int i = 0; i < len; i++)
            {
                String tmp = words[i];
                value[i] = 0;
                for (int j = 0; j < tmp.Length; j++)
                {
                    value[i] |= 1 << (tmp[j] - 'a');  // 用二进制表示
                }
            }
            int maxProduct = 0;
            for (int i = 0; i < len; i++)
                for (int j = i + 1; j < len; j++)
                {
                    if ((value[i] & value[j]) == 0 && (words[i].Length * words[j].Length > maxProduct))
                        maxProduct = words[i].Length * words[j].Length;
                }
            return maxProduct;
        }
    }
}
