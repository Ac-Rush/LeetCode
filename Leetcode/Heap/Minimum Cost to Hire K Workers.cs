using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
   public class Minimum_Cost_to_Hire_K_Workers
    {
       
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
                var ans = a[0].CompareTo(b[0]);
                if (ans == 0)
                {
                    return a[1].CompareTo(b[1]);
                }
                return ans;
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
