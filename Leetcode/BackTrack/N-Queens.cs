using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
  public    class N_Queens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> queens = new List<IList<string>>();
            dfs(queens, new int[n], 0);
            return queens;
        }

        private static void dfs(List<IList<string>> all, int[] result, int row)
        {
            if (row == result.Length)
            {
                List<string> tmpLst = new List<string>();
                for (int j = 0; j < result.Length; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int k = 0; k < result.Length; k++)
                        if (result[j] == k) sb.Append("Q");
                        else sb.Append(".");
                    tmpLst.Add(sb.ToString());
                }
                all.Add(tmpLst);
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                bool bAvail = true;
                for (int j = 0; j < row; j++)
                    if (result[j] == i || Math.Abs(result[j] - i) == row - j) bAvail = false;
                if (bAvail)
                {
                    result[row] = i;  //用 array 就不用 remove 这样不错
                    dfs(all, result, row + 1);
                }
            }
        }
    }


    public class N_Queens_2
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> queens = new List<IList<string>>();
            dfs(queens, new List<int>(), 0);
            return queens;
        }

        private static void dfs(List<IList<string>> all, List<int> result, int row)
        {
            if (row == result.Count)
            {
                List<string> tmpLst = new List<string>();
                for (int j = 0; j < result.Count; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int k = 0; k < result.Count; k++)
                        if (result[j] == k) sb.Append("Q");
                        else sb.Append(".");
                    tmpLst.Add(sb.ToString());
                }
                all.Add(tmpLst);
                return;
            }

            for (int i = 0; i < result.Count; i++)
            {
                bool bAvail = true;
                for (int j = 0; j < row; j++)
                    if (result[j] == i || Math.Abs(result[j] - i) == row - j) bAvail = false;
                if (bAvail)
                {
                    result[row] = i;  
                    dfs(all, result, row + 1);
                }
            }
        }
    }
}
