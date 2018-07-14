using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Majority_Element_II
    {
        public IList<int> MajorityElement(int[] nums)
        {
            int count1 = 0;
            int? candidate1 = null;

            int count2 = 0;
            int? candidate2 = null;

            foreach (int num in nums)
            { 
                if (num == candidate1) count1++;  //这个必须在前面，用来去重
                else if (num == candidate2) count2++;
                else if (count1 == 0)
                {
                    candidate1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
            count1 = 0; count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1) count1 += 2;
                else count1--;
                if (num == candidate2) count2 += 2;
                else count2--;
            }
            var ans = new List<int>();
            if (count1 > 0) ans.Add(candidate1.Value);
            if (count2 >0) ans.Add(candidate2.Value);
            return ans;
        }
    }


    class Majority_Element_II_2
    {
        public IList<int> MajorityElement(int[] nums)
        {
            int count1 = 0;
            int? candidate1 = null;

            int count2 = 0;
            int? candidate2 = null;

            foreach (int num in nums)
            {
                 if (num == candidate1) count1++;
                else if (num == candidate2) count2++;
                 if (count1 == 0)
                {
                    candidate1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
            count1 = 0; count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1) count1 += 2;
                else count1--;
                if (num == candidate2) count2 += 2;
                else count2--;
            }
            var ans = new List<int>();
            if (count1 > 0) ans.Add(candidate1.Value);
            if (count2 > 0) ans.Add(candidate2.Value);
            return ans;
        }
    }
}
