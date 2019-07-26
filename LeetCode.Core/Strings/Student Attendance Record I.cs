using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Student_Attendance_Record_I
    {
        public bool CheckRecord(string s)
        {
            var countA = 0;
            var countL = 0;
            foreach (var c in s)
            {
                if (c == 'A') //如果是缺席， 
                {
                    if (++countA > 1)  //如果多余了1个缺席
                    {
                        return false;  //返回 false
                    }
                 
                }
                if (c == 'L')  //如果是 late
                {
                    if (++countL > 2)  //如果连续多余2个
                    {
                        return false;
                    }
                }
                else // my bug 没看清题
                {
                    countL = 0;  // late 置0
                }
            }
            return true;
        }
    }
}
