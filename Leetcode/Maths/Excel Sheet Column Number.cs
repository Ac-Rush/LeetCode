using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Excel_Sheet_Column_Number
    {
       /// <summary>
       ///  my solution
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
        public int TitleToNumber(string s)
        {
            var ret = 0;
            foreach (char t in s)
            {
                ret = ret*26 + t - 'A' + 1;
            }
            return ret;
        }
    }
}
