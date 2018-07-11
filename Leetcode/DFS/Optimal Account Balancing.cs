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
}
