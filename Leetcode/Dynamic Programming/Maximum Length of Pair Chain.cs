using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-length-of-pair-chain/description/
    /*
     You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.

Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c. Chain of pairs can be formed in this fashion.

Given a set of pairs, find the length longest chain which can be formed. You needn't use up all the given pairs. You can select pairs in any order.

Example 1:
Input: [[1,2], [2,3], [3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4]
Note:
The number of given pairs will be in the range [1, 1000].
    */
    /// </summary>
    class Maximum_Length_of_Pair_Chain
    {

        public int FindLongestChain(int[,] pairs)
        {
            pairs = pairs.OrderBy(row => row[0]);
            int N = pairs.GetLength(0);
            int[] dp = new int[N];
            var max = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (int j = 1; j < N; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    if (pairs[i, 1] < pairs[j, 0])
                    {
                        dp[j] = Math.Max(dp[j], dp[i] + 1);
                    }
                }

                max = Math.Max(max, dp[j]);
            }

            return max;
        }


        /// <summary>
        /// 贪心， 找第二个最小的
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public int findLongestChain2(int[,] pairs)
        {
            pairs = pairs.OrderBy(row => row[1]);
            int cur = int.MinValue, ans = 0;
            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                if (cur < pairs[i,0])
                {
                    cur = pairs[i, 1];
                    ans++;
                }
            }
            return ans;
        }
    }


    public static class MultiDimensionalArrayExtensions
    {
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().OrderBy(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector in descending order.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderByDescending<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().
                OrderByDescending(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Converts a two dimensional array to single dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source two dimensional array.</param>
        /// <returns>The repackaged two dimensional array as a single dimension based on rows.</returns>
        private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
        {
            T[] arRow;

            for (int row = 0; row < source.GetLength(0); ++row)
            {
                arRow = new T[source.GetLength(1)];

                for (int col = 0; col < source.GetLength(1); ++col)
                    arRow[col] = source[row, col];

                yield return arRow;
            }
        }
        /// <summary>
        ///   Converts a collection of rows from a two dimensional array back into a two dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source collection of rows to convert.</param>
        /// <returns>The two dimensional array.</returns>
        private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
        {
            T[,] twoDimensional;
            T[][] arrayOfArray;
            int numberofColumns;

            arrayOfArray = source.ToArray();
            numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
            twoDimensional = new T[arrayOfArray.Length, numberofColumns];

            for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
                for (int col = 0; col < numberofColumns; ++col)
                    twoDimensional[row, col] = arrayOfArray[row][col];

            return twoDimensional;
        }
    }

    public static class MyEnumerableExtension
    {
        public static IEnumerable AsEnumerable(this int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                yield return arr[i, j];
        }

    }
}