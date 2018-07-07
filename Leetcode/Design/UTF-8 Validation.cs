using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    class UTF_8_Validation
    {
        public bool ValidUtf8(int[] data)
        {
            int count = 0;
            foreach (var c in data)
            {
                if (count == 0)
                {
                    if ((c >> 5) ==6) count = 1;  //0b110     如果移动5位是 110 那么后面还有一个数
                    else if ((c >> 4) ==14) count = 2; //0b1110  如果移动4位是 1110 那么后面还有2个数
                    else if ((c >> 3) == 30) count = 3;// 0b11110 如果移动3位是 11110 那么后面还有3个数
                    else if ((c >> 7) != 0) return false;    //如果移动7 位 不是0 那么不对
                }
                else
                {
                    if ((c >> 6) != 2) return false;//0b10  不是第一个数 ， 后面的数必须  10开头
                    count--;
                }
            }

            return count == 0;
        }
    }
}
