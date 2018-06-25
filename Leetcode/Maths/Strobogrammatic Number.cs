using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Strobogrammatic_Number
    {
        /// <summary>
        /// 太赞了
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsStrobogrammatic(string num)
        {
            for (int i = 0, j = num.Length - 1; i <= j; i++, j--)
                if (!"00 11 88 696".Contains(num[i] + "" + num[j]))
                    return false;
            return true;
        }
    }
}
