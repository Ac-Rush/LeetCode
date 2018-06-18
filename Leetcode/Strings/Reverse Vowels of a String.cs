using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_Vowels_of_a_String
    {
        public string ReverseVowels(string s)
        {
            var array = s.ToCharArray();
            var set = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }; //my bug 少了大写 要和面试官确认一下
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                while (start < end && !set.Contains(array[start])) start++;
                while (start < end && !set.Contains(array[end])) end--;
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;  //my bug  忘了 start++ end --
                end--;
            }
            return new string(array); // my bug string不能直接写（readonly） 需要先弄到 char[]里
        }
    }
}
