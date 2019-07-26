using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Rabbits_in_Forest
    {
        public int NumRabbits(int[] answers)
        {
            var result = 0;
            var set = new Dictionary<int,int>();  ///<answers, count>
            foreach (var ans in answers)
            {

                if (!set.ContainsKey(ans))
                {
                    set[ans] = 0;
                }
                set[ans]++;
            }
            foreach (var ans in set.Keys)
            {
                if (ans < set[ans])
                {
                    result += ((set[ans] + ans)/(ans+1)) * (ans + 1);
                }
                else
                {
                    result += ans + 1;
                }
            }
            return result;
        }


        public int NumRabbits2(int[] answers)
        {
            var result = 0;
            var set = new Dictionary<int, int>();  ///<answers, count>
            foreach (var ans in answers)
            {

                if (!set.ContainsKey(ans))
                {
                    set[ans] = 0;
                }
                set[ans]++;
            }
            foreach (var n in set.Keys)
            {
                int group = set[n] / (n + 1);
                result += set[n] % (n + 1) != 0 ? (group + 1) * (n + 1) : group * (n + 1);
            }
            return result;
        }
    }
}
