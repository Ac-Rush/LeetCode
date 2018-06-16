using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    public class Is_Graph_Bipartite
    {
        public static bool IsBipartite(int[][] graph)
        {
            var setA = new HashSet<int>();
            var setB = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {

                    if ((setA.Contains(i) && setA.Contains(j)) || (setB.Contains(i) && setB.Contains(j)))
                    {
                        return false;
                    }
                    if (setA.Contains(i))
                    {
                        setB.Add(j);
                    }else if (setB.Contains(i))
                    {
                        setA.Add(j);
                    }
                    else
                    {
                        if (setA.Contains(j))
                        {
                            setB.Add(i);
                        }
                        else
                        {
                            setA.Add(i);
                        }
                    }
                }
            }
            return true;
        }
    }
}
