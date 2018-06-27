using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.经典代码
{
    class PermuteC
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Permute2(int[] nums)
        {
            PermuteRecursion(nums, 0);

            return res;
        }

        private void PermuteRecursion(int[] num, int i)
        {
            if (i == num.Length)
            {
                res.Add(num.ToList());
            }

            for (int j = i; j < num.Length; j++)
            {
                Swap(num, i,j);
                this.PermuteRecursion(num, i + 1);
                Swap(num, i, j);
            }
        }
        private static void Swap(int[] nums, int a,  int b)
        {
            var swap = nums[a];
            nums[a] = nums[b];
            nums[b] = swap;
        }



        private class SubSet
        {
            //模板
            /// <summary>
            /// subset 模板
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public List<List<int>> subsets(int[] nums)
            {
                List<List<int>> list = new List<List<int>>();
              //  System.Array.Sort(nums);  可以不用排序
                backtrack(list, new List<int>(), nums, 0);
                return list;
            }

            private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int start)
            {
                list.Add(new List<int>(tempList));
                for (int i = start; i < nums.Length; i++)
                {
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums, i + 1);
                    tempList.RemoveAt(tempList.Count - 1);  //c# 是 tempList.RemoveAt
                }
            }

        }

        private class SubSetWithDup
        {
            //模板
            /// <summary>
            /// SubSetWithDup 模板
            /// 1. 在subsetsWithDup 需要对数组进行排序
            /// 2   if (i > start && nums[i] == nums[i - 1]) continue; // skip duplicates  //就多了这句话
            ///    去重
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public List<List<int>> subsetsWithDup(int[] nums)
            {
                List<List<int>> list = new List<List<int>>();
                System.Array.Sort(nums);    // 1 排序  这个不能丢
                backtrack(list, new List<int>(), nums, 0);
                return list;
            }

            private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int start)
            {
                list.Add(new List<int>(tempList));
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1]) continue; // skip duplicates  //就多了这句话
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums, i + 1);
                    tempList.RemoveAt(tempList.Count - 1); //c# 是 tempList.RemoveAt
                }
            }
        }

        public class PermuteCC
        {
            /// <summary>
            /// 全排列Permutations
            /// 效率不如 最上面的交换的方法， 可以用hashset来去重
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public IList<IList<int>> Permute(int[] nums)
            {
                var list = new List<IList<int>>();
                //  System.Array.Sort(nums);   // not necessary
                backtrack(list, new List<int>(), nums);
                return list;
            }

            private void backtrack(List<IList<int>> list, List<int> tempList, int[] nums)
            {
                if (tempList.Count == nums.Length)
                {
                    list.Add(new List<int>(tempList));
                }
                else
                {
                    foreach (int t in nums)
                    {
                        if (tempList.Contains(t)) continue; // 这个效率不如 最上面的那种， 优化方法可以用 hashset去重
                        tempList.Add(t);
                        backtrack(list, tempList, nums);
                        tempList.RemoveAt(tempList.Count - 1);  //remove At
                    }
                }
            }
        }

        public class PermuteCC2
        {
            /// <summary>
            /// 全排列Permutations  contains duplicates 有重复的
            /// 效率不如 最上面的交换的方法， 可以用hashset来去重
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public List<IList<int>> Permute(int[] nums)
            {
                var list = new List<IList<int>>();
                System.Array.Sort(nums); 
                backtrack(list, new List<int>(), nums, new bool[nums.Length]);
                return list;
            }

            private void backtrack(List<IList<int>> list, List<int> tempList, int[] nums, bool[] used)
            {
                if (tempList.Count == nums.Length)
                {
                    list.Add(new List<int>(tempList));
                }
                else
                {
                    for (int i = 0; i < nums.Length; i++)  //不像 subset 不用传index 从0开始
                    {
                        //不向上面的去重方式，上面的去重方式是不同递归间的去重
                        //这个去重，是不同递归间 + 本层递归去重（如同subset）
                        if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;  //去重
                        used[i] = true;
                        tempList.Add(nums[i]);
                        backtrack(list, tempList, nums, used);
                        used[i] = false;
                        tempList.RemoveAt(tempList.Count - 1);
                    }
                }
            }
        }

        public class Combination_C
        {
            /// <summary>
            /// Combination Sum
            /// 不是 subset的sum, 还加上了剪枝，如果nums全部大于等0
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public List<List<int>> combinationSum(int[] nums, int target)
            {
                List<List<int>> list = new List<List<int>>();
                System.Array.Sort(nums);
                backtrack(list, new List<int>(), nums, target, 0);
                return list;
            }

            private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int remain, int start)
            {
                if (remain < 0) return;
                else if (remain == 0) list.Add(new List<int>(tempList));
                else
                {
                    for (int i = start; i < nums.Length; i++)
                    {
                        tempList.Add(nums[i]);
                        //因为下一个 还是 i, 是因为可以重复用一个num
                        backtrack(list, tempList, nums, remain - nums[i], i); // not i + 1 because we can reuse same elements
                        tempList.Remove(tempList.Count - 1);
                    }
                }

                var arr = new char[3];
                var s = new string(arr, 0, 2);
                s.ToCharArray();
            }
        }

        public class Combination_C_II
        {
            /// <summary>
            /// Combination Sum
            /// 像是 subset 去重的sum, 还加上了剪枝，如果nums全部大于等0
            /// (can't reuse same element)
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public List<List<int>> combinationSum2(int[] nums, int target)
            {
                List<List<int>> list = new List<List<int>>();
                System.Array.Sort(nums);
                backtrack(list, new List<int>(), nums, target, 0);
                return list;
            }

            private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int remain, int start)
            {
                if (remain < 0) return;
                else if (remain == 0) list.Add(new List<int>(tempList));
                else
                {
                    for (int i = start; i < nums.Length; i++)
                    {
                        if (i > start && nums[i] == nums[i - 1]) continue; // skip duplicates  
                        tempList.Add(nums[i]);
                        backtrack(list, tempList, nums, remain - nums[i], i + 1);  //不是 i 而是i+1 不能重复用同一个
                        tempList.Remove(tempList.Count - 1);
                    }
                }
            }
        }


        public class Palindrome_C
        {
            public List<List<string>> partition(string s)
            {
                List<List<string>> list = new List<List<string>>();
                backtrack(list, new List<string>(), s, 0);
                return list;
            }

            public void backtrack(List<List<String>> list, List<String> tempList, String s, int start)
            {
                if (start == s.Length)
                    list.Add(new List<string>(tempList));
                else
                {
                    for (int i = start; i < s.Length; i++)
                    {
                        if (isPalindrome(s, start, i))
                        {
                            tempList.Add(s.Substring(start, i + 1 - start));
                            backtrack(list, tempList, s, i + 1);
                            tempList.RemoveAt(tempList.Count - 1);
                        }
                    }
                }
            }

            public bool isPalindrome(String s, int low, int high)
            {
                while (low < high)
                    if (s[low++] != s[high--]) return false;
                return true;
            }
        }
    }
}
