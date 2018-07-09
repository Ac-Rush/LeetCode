using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Minimize_Max_Distance_to_Gas_Station_DP
    {
        //Let dp[n][k] be the answer for adding k more gas stations to the first n intervals of stations. 
        //We can develop a recurrence expressing dp[n][k] in terms of dp[x][y] with smaller (x, y).
        public double MinmaxGasDist(int[] stations, int K)
        {
            int N = stations.Length;
            double[] deltas = new double[N - 1];
            for (int i = 0; i < N - 1; ++i)
                deltas[i] = stations[i + 1] - stations[i];

            var dp = new double[N - 1,K + 1];
            //dp[i][j] = answer for deltas[:i+1] when adding j gas stations
            for (int i = 0; i <= K; ++i)
                dp[0,i] = deltas[0] / (i + 1);

            for (int p = 1; p < N - 1; ++p)
                for (int k = 0; k <= K; ++k)
                {
                    double bns = 999999999;
                    for (int x = 0; x <= k; ++x)
                        bns = Math.Min(bns, Math.Max(deltas[p] / (x + 1), dp[p - 1,k - x]));
                    dp[p,k] = bns;
                }

            return dp[N - 2,K];
        }
    }


    class Minimize_Max_Distance_to_Gas_Station_BF
    {
        /*  这个方法很直接Time Complexity: O(N K)O(NK)
     As in Approach #1, let's look at deltas, the distances between adjacent gas stations.

Let's repeatedly add a gas station to the current largest interval, so that we add K of them total. This greedy approach is correct because if we left it alone, then our answer never goes down from that point on.
    */
        public double MinmaxGasDist(int[] stations, int K)
        {
            int N = stations.Length;
            double[] deltas = new double[N - 1];
            for (int i = 0; i < N - 1; ++i)
                deltas[i] = stations[i + 1] - stations[i]; //求 delta

            int[] count = new int[N - 1];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 1;   //初始值，如果 两个点之间没有加入 ，就是1
            }

            for (int k = 0; k < K; ++k)  //每次挑一个 间距最大的加入
            {
                // Find interval with largest part
                int best = 0;
                for (int i = 0; i < N - 1; ++i)
                    if (deltas[i] / count[i] > deltas[best] / count[best])
                        best = i;

                // Add gas station to best interval
                count[best]++;
            }

            double ans = 0;
            for (int i = 0; i < N - 1; ++i)
                ans = Math.Max(ans, deltas[i] / count[i]);

            return ans;
        }
    }

   public  class Minimize_Max_Distance_to_Gas_Station_Heap
    {
        /// <summary>
        /// 这个写的不对
        /// </summary>
        /// <param name="stations"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        /*  这个方法很直接Time Complexity: O(KlogN)  
    通过 BF算法来的， 用了 heap 来找 最大 ，所以优化成了 logN
    */
        public double MinmaxGasDist(int[] stations, int K)
        {
            /*
            int N = stations.length;
            PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) ->
    
                (double)b[0] / b[1] < (double)a[0] / a[1] ? -1 : 1);
            for (int i = 0; i < N - 1; ++i)
                pq.add(new int[] { stations[i + 1] - stations[i], 1 });

            for (int k = 0; k < K; ++k)
            {
                int[] node = pq.poll();
                node[1]++;
                pq.add(node);
            }

            int[] node = pq.poll();
            return (double)node[0] / node[1];
            */
            var n = stations.Length;
            var set = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
            {
                var result =  (double) b[0]/b[1] > (double) a[0]/a[1] ? -1 : 1;
                if (result == 0)
                {
                    return a[2].CompareTo(b[2]);  //这里完全是因为 SS不支持重复
                }
                return result;
            }
        ));
            for (int i = 0; i < n - 1; ++i)
            {
                set.Add(new int[] {stations[i + 1] - stations[i], 1, stations[i]});
            }
            int[] node;
            for (int k = 0; k < K; ++k)
            {
                node = set.Max;
                set.Remove(node);
                node[1]++;
                set.Add(node);
            }

            node = set.Max;
            return (double)node[0] / node[1];
        }
    }

    public class Minimize_Max_Distance_to_Gas_Station_BinarySearch
    {

        /*  这个方法很直接Time Complexity: Time Complexity: O(N \log W)O(NlogW), where NN is the length of stations, and W = 10^{14}W=10
​14
​​  is the range of possible answers (10^810
​8
​​ ), divided by the acceptable level of precision (10^{-6}10
​−6
​​ ).
    通过 BF算法来的， 用了 heap 来找 最大 ，所以优化成了 logN
    */
        public double MinmaxGasDist(int[] stations, int K)
        {
            int N = stations.Length;
            double lo = 0, hi = stations[N - 1] - stations[0];
            while (hi - lo > 1e-6)
            {
                double mi = (lo + hi) / 2.0;
                if (possible(mi, stations, K))
                    hi = mi;
                else
                    lo = mi;
            }
            return lo;
        }
        public bool possible(double D, int[] stations, int K)
        {
            int used = 0;
            for (int i = 0; i < stations.Length - 1; ++i)
                used += (int)((stations[i + 1] - stations[i]) / D);
            return used <= K;
        }
    }
}
