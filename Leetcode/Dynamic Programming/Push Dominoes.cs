using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Push_Dominoes
    {
        public string PushDominoes(string dominoes)
        {
            char[] A = dominoes.ToCharArray();
            int N = A.Length;
            int[] forces = new int[N];

            int force = 0;
            for (int i = 0; i < N; ++i)
            {
                if (A[i] == 'R') force = N;
                else if (A[i] == 'L') force = 0;
                else force = Math.Max(force - 1, 0);
                forces[i] += force;
            }

            force = 0;
            for (int i = N - 1; i >= 0; --i)
            {
                if (A[i] == 'L') force = N;
                else if (A[i] == 'R') force = 0;
                else force = Math.Max(force - 1, 0);
                forces[i] -= force;
            }

            StringBuilder ans = new StringBuilder();
            foreach (int f in forces)
            {
                ans.Append(f > 0 ? 'R' : f < 0 ? 'L' : '.');
            }
                
            return ans.ToString();
        }
    }
}
