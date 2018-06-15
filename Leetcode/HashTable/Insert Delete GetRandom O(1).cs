using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class RandomizedSet
    {

        private List<int> nums;
        private Dictionary<int, int> locs;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            nums = new List<int>();
            locs = new Dictionary<int, int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            var contain = locs.ContainsKey(val);
            if (contain) return false;
            locs[val] = nums.Count;
            nums.Add(val);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            var contain = locs.ContainsKey(val);
            if (!contain) return false;
            int loc = locs[val];
            if (loc < nums.Count - 1)  //把最后一个挪过来
            { // not the last one than swap the last one with this val
                int lastone = nums[nums.Count - 1];
                nums[loc] =  lastone;
                locs[lastone] = loc;
            }
            locs.Remove(val);
            nums.RemoveAt(nums.Count - 1);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return nums[new Random().Next(nums.Count)];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
