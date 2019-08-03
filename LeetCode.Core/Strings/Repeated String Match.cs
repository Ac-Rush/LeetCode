using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Repeated_String_Match_1
    {
        /// <summary>
        ///  时间复杂度 O(N*(N+M)), where M, N are the lengths of strings A, B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int RepeatedStringMatch(string A, string B)
        {
            int count = 1;
            StringBuilder S = new StringBuilder(A);
            while (S.Length < B.Length)  // 1. 只有 S的长度 大于 B的长度，才有可能找到，
            {
                S.Append(A);
                count++;
            }
            if (S.ToString().IndexOf(B) >= 0) return count; //如果有就 返回count
            if (S.Append(A).ToString().IndexOf(B) >= 0) return count + 1; // 再append一个A， 这样确保以A的每一个字母开始都能扎到，  返回 count+1
            return -1;  //如果没有就再也找不到了
        }
    }

    class Repeated_String_Match
    {
        public int RepeatedStringMatch(string A, string B)
        {
            //这就是从每一位 A开始， 循环的在 A里找B， 如果j结束时 B的length，就找到了，并返回
            for (int i = 0, j = 0; i < A.Length; ++i)  
            {
                for (j = 0; j < B.Length && A[(i + j) % A.Length] == B[j]; ++j) ;
                if (j == B.Length) return (i + j) / A.Length + ((i + j) % A.Length != 0 ? 1 : 0);
            }
            return -1;
        }
    }
}
