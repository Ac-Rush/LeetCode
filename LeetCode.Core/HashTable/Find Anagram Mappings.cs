using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Find_Anagram_Mappings
    {
        public int[] AnagramMappings(int[] A, int[] B)
        {
            var dict = new Dictionary<int, int >(); // <encode, index>

            for (int index = 0; index < B.Length; index++)
            {
                dict[B[index]] = index;
            }

            var result = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = dict[A[i]];
            }
            return result;
        }
    }
}
