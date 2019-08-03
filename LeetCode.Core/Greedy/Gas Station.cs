using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Greedy
{
    class Gas_Station
    {
        /*
         *
         * If car starts at A and can not reach B. Any station between A and B
can not reach B.(B is the first station that A can not reach.)
If the total number of gas is bigger than the total number of cost. There must be a solution.
(Should I prove them?)
         */
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int start=0,total=0,tank=0;
            //if car fails at 'start', record the next station
            for (int i = 0; i < gas.Length; i++) if ((tank = tank + gas[i] - cost[i]) < 0) { start = i + 1; total += tank; tank = 0; }
            return (total + tank < 0) ? -1 : start;
        }
    }
}
