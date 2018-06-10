using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Egg_Dropping_Puzzle
    {
        /*
         * 1) Optimal Substructure:
            When we drop an egg from a floor x, there can be two cases (1) The egg breaks (2) The egg doesn’t break.

            1) If the egg breaks after dropping from xth floor, then we only need to check for floors lower than x with remaining eggs; so the problem reduces to x-1 floors and n-1 eggs
            2) If the egg doesn’t break after dropping from the xth floor, then we only need to check for floors higher than x; so the problem reduces to k-x floors and n eggs.
         * 
         *  k ==> Number of floors
            n ==> Number of Eggs
            eggDrop(n, k) ==> Minimum number of trials needed to find the critical
                    floor in worst case.
            eggDrop(n, k) = 1 + min{max(eggDrop(n - 1, x - 1), eggDrop(n, k - x)):     // 1+ 是因为已经试了一次了， 如果碎了：eggDrop(n - 1, x - 1)  如果没碎 eggDrop(n, k - x)
                 x in {1, 2, ..., k}}
         * 
         * 
         */


        /* Function to get minimum number of 
    trials needed in worst case with n 
    eggs and k floors */
        static int EggDrop(int n, int k)
        {
            // If there are no floors, then 
            // no trials needed. OR if there
            // is one floor, one trial needed.
            if (k == 1 || k == 0)
                return k;

            // We need k trials for one egg
            // and k floors
            if (n == 1)
                return k;

            int min = int.MaxValue;
            int x, res;

            // Consider all droppings from 
            //1st floor to kth floor and
            // return the minimum of these
            // values plus 1.
            for (x = 1; x <= k; x++)
            {
                res = Math.Max(EggDrop(n - 1, x - 1),
                               EggDrop(n, k - x));
                if (res < min)
                    min = res;
            }

            return min + 1;
        }


        /* Function to get minimum number of 
   trials needed in worst case with n
   eggs and k floors */
        static int eggDropDP(int n, int k)
        {

            /* A 2D table where entery eggFloor[i][j]
            will represent minimum number of trials
            needed for i eggs and j floors. */
            int[,] eggFloor = new int[n + 1, k + 1];
            int res;
            int i, j, x;

            // We need one trial for one floor and0
            // trials for 0 floors
            for (i = 1; i <= n; i++)
            {
                eggFloor[i, 1] = 1;
                eggFloor[i, 0] = 0;
            }

            // We always need j trials for one egg
            // and j floors.
            for (j = 1; j <= k; j++)
                eggFloor[1, j] = j;

            // Fill rest of the entries in table 
            // using optimal substructure property
            for (i = 2; i <= n; i++)
            {
                for (j = 2; j <= k; j++)
                {
                    eggFloor[i, j] = int.MaxValue;
                    for (x = 1; x <= j; x++)
                    {
                        res = 1 + Math.Max(eggFloor[i - 1, x - 1],
                                      eggFloor[i, j - x]);
                        if (res < eggFloor[i, j])
                            eggFloor[i, j] = res;
                    }
                }
            }

            // eggFloor[n][k] holds the result
            return eggFloor[n, k];

        }
    }
}
