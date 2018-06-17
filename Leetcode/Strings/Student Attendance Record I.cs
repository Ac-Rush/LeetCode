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
                if (c == 'A')
                {
                    if (++countA > 1)
                    {
                        return false;
                    }
                 
                }
                if (c == 'L')
                {
                    if (++countL > 2)
                    {
                        return false;
                    }
                }
                else // my bug 没看清题
                {
                    countL = 0;
                }
            }
            return true;
        }
    }
}
