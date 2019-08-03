using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
   public class Minimum_Cost_to_Hire_K_Workers
    {

        /*
         * 
         
            注意到我们需要小的W/Q比，而且所有人这个比值是一样的，但是假定我们选了k个人，最后给他们的开的W/Q又一定是k个人中最大的，不然有的人就满足不了最小的wage，所以W/Q是由大的数值主导。

这样的话，就可以先对W/Q排序，这样W/Q值就是最后选的那个人，然后只要求Q总和最小的k个就好，于是sort+PriorityQueue
    */
        /// <summary>
        /// wrong anwser
        /// </summary>
        /// <param name="q"></param>
        /// <param name="w"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public double MincostToHireWorkers(int[] q, int[] w, int K)
        {
            List<double[]> workers = new List<double[]>();
            for (int i = 0; i < q.Length; ++i)
                workers.Add(new double[] {(double) (w[i])/q[i], (double) q[i]});
            workers.Sort((a,b)=> a[0].CompareTo(b[0]));
            double res = Double.MaxValue, qsum = 0;
            var pq = new SortedSet<double[]>(Comparer<double[]>.Create((a, b) =>
            {
                var ans = a[0] - b[0];
                if (ans == 0)
                {
                    return (int) (a[1] - b[1]) ;
                }
                return (int) ans;
            }));
        var id = 0;
            foreach (double[] worker in workers)
            {
                qsum += worker[1];
                pq.Add(new double[]{ -worker[1] ,id});
                if (pq.Count > K)
                {
                    var min= pq.Min();
                    qsum += min[0];
                    pq.Remove(min);
                }
                if (pq.Count == K) res = Math.Min(res, qsum * worker[0]);
                id++;
            }
            return res;
        }
    }
}
