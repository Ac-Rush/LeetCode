using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    /*
This is a straight forward brutal force problem.
We first replay all the transactions while keeping a balance for each people
Then we try to settle the money asap.

How do we settle?
We group the balances into 2 arrays, pos and neg
We use a nested for loop to try all the possible sequence of settlement.


*/
    /// <summary>
    /// wrong answer
    /// </summary>
    class Optimal_Account_Balancing
    {
        public int MinTransfers(int[,] transactions)
        {
            return 0;
        }
        private void helper(Dictionary<int, int> map, int[] count)
        {
            int max = getMax(map);
            int min = getMin(map);
            //This means richest one and poorest one are both $0, means balance.
            if (map[max] == 0 && map[min] == 0) return;
            //Or we get the min abs value of max and min
            int minValue = Math.Min(map[max], -map[min]);
            //let the richest give the poorest the as much as possible money
            map[max] =  map[max] - minValue;
            map[min] = map[min] + minValue;
            //after done this, add the count
            count[0]++;
            helper(map, count);
        }
        private int getMax(Dictionary<int, int> map)
        {
            int max = -1;
            foreach (var  key in map.Keys)
            {
                if (max == -1) max = key;
                else if (map[key] > map[max])
                {
                    max = key;
                }
            }
            return max;
        }
        private int getMin(Dictionary<int, int> map)
        {
            int min = -1;
            foreach (var key in map.Keys)
            {
                if (min == -1) min = key;
                else if (map[key] < map[min])
                {
                    min = key;
                }
            }
            return min;
        }
    }


    class Optimal_Account_Balancing_C
    {
        public int MinTransfers(int[,] transactions)
        {
            // convert the transactions to a balance count for each person
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < transactions.GetLength(0); i++)
            {
                if (!map.ContainsKey(transactions[i, 0])) map[transactions[i, 0]] = 0;
                if (!map.ContainsKey(transactions[i, 1])) map[transactions[i, 1]] = 0;

                map[transactions[i, 0]] += transactions[i, 2];
                map[transactions[i, 1]] -= transactions[i, 2];
            }

            // take the non-zero balances and sort them into an array
            // the sorting will help with DFS pruning
            List<int> nums = map.Values.Where(x => x != 0).OrderBy(x => x).ToList();

            int cnt = 0;
            int targetLen = 2;
            while (nums.Count > 0)
            {
                // try to find a set of length = targetLen which sum to 0
                List<int> indexes = new List<int>();
                bool found = Find(nums, indexes, targetLen, 0, 0);

                if (found)
                {
                    // because this is the minimum length set that can sum to zero, 
                    // this set will require (len - 1) transactions to balance
                    cnt += indexes.Count - 1;

                    // remove these values from the list and try again for another set of this length
                    int indexesIndex = 0;
                    List<int> next = new List<int>();
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (indexesIndex < indexes.Count && i == indexes[indexesIndex]) indexesIndex++;
                        else next.Add(nums[i]);
                    }
                    nums = next;
                }
                else
                {
                    // no set of this length was found, try the next length
                    targetLen++;
                }
            }

            return cnt;
        }

        // DFS - find targetLen amount of items that sum to zero
        // store the indexes of these elements
        public bool Find(List<int> nums, List<int> indexes, int targetLen, int sum, int index)
        {
            if (sum > 0) return false;
            if (indexes.Count == targetLen && sum == 0) return true;
            if (indexes.Count == targetLen && sum != 0) return false;
            if (nums.Count - index < targetLen - indexes.Count) return false;

            for (int i = index; i < nums.Count; i++)
            {
                indexes.Add(i);
                if (Find(nums, indexes, targetLen, sum + nums[i], i + 1))
                {
                    return true;
                }
                indexes.RemoveAt(indexes.Count - 1);
            }
            return false;
        }
    }
}
