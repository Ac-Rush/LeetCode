using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Minimum_Add_to_Make_Parentheses_Valid
    {
        public int MinAddToMakeValid(string S)
        {
            //count 需要的左括号
            //stk 需要的右括号
            int count = 0, stk = 0;
            foreach(var c in S)
            {
                if (c == '(') { ++stk; }
                else if (stk <= 0) { ++count; }
                else { --stk; }
            }
            return count + stk;
        }
    }
}
