using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Student_Attendance_Record_II
    {


        public int CheckRecord(int n)
        {
            var MOD = 1000000007;
            var f = new int[n + 1,2,3];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    f[0, i, j] = 1;
                }
            }
            for (int i = 1; i <= n; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        int val = f[i - 1,j,2]; // ...P
                        if (j > 0) val = (val + f[i - 1,j - 1,2]) % MOD; // ...A
                        if (k > 0) val = (val + f[i - 1,j,k - 1]) % MOD; // ...L
                        f[i,j,k] = val;
                    }
            return f[n,1,2];

        }




        public int CheckRecord2(int n)
        {
            int m = 1000000007;
            var A = new int[n];
            var P = new int[n];
            var L = new int[n];

            P[0] = 1;
            L[0] = 1;
            L[1] = 3;
            A[0] = 1;
            A[1] = 2;
            A[2] = 4;

            if (n == 1) return 3;

            for (int i = 1; i < n; i++)
            {
                A[i - 1] %= m;
                P[i - 1] %= m;
                L[i - 1] %= m;

                P[i] = ((A[i - 1] + P[i - 1]) % m + L[i - 1]) % m;

                if (i > 1) L[i] = ((A[i - 1] + P[i - 1]) % m + (A[i - 2] + P[i - 2]) % m) % m;

                if (i > 2) A[i] = ((A[i - 1] + A[i - 2]) % m + A[i - 3]) % m;
            }

            return ((A[n - 1] % m + P[n - 1] % m) % m + L[n - 1] % m) % m;

        }
    }
}
