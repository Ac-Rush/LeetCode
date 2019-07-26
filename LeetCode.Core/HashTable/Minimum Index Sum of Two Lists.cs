using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Minimum_Index_Sum_of_Two_Lists
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var result = new List<string>();
            var set = new Dictionary<string,int>();
            for (int index = 0; index < list1.Length; index++)
            {
                set[list1[index]] = index;
            }
            var min = int.MaxValue;
            for (int index = 0; index < list2.Length; index++)
            {
                var s = list2[index];
                if (set.ContainsKey(s))
                {
                    var curt = index + set[s];
                    if (curt < min)
                    {
                        min = curt;  //my bug
                        result.Clear();
                        result.Add(s);
                    }
                    else if(curt == min)
                    {
                        result.Add(s);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
