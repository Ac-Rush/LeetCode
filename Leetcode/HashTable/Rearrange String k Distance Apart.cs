using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    /// <summary>
    ///  时间复杂度 是 O(N)  那个26个的for 根本就不算
    /// </summary>
    class Rearrange_String_k_Distance_Apart
    {
        public string RearrangeString(string s, int k)
        {
            int length = s.Length;
            int[] count = new int[26];  //统计 count
            int[] valid = new int[26];
            for (int i = 0; i < length; i++)
            {
                count[s[i] - 'a']++; //统计 count
            }
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
            {
                int candidatePos = findValidMax(count, valid, index); //找 candidate
                if (candidatePos == -1) return "";  //如果不存在
                count[candidatePos]--;  //count -1
                valid[candidatePos] = index + k;  // 设置这个点的下一个validate的index
                sb.Append((char)('a' + candidatePos));
            }
            return sb.ToString();
        }

        private int findValidMax(int[] count, int[] valid, int index)
        {
            int max = int.MinValue;
            int candidatePos = -1;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0 && count[i] > max && index >= valid[i])  //找大的， 并且 valid
                {
                    max = count[i];
                    candidatePos = i;
                }
            }
            return candidatePos;
        }
    }
}
