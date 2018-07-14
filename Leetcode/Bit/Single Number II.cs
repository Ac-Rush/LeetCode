using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    /*
     

        我们想要达到的效果其实是——

　　　　　　　　　　  a  b

初始状态　　　　  ：   0   0

第一次碰见某个数x：   0   x（把x记录在b中）

第二次碰见某个数x：   x   0（把x记录在a中）

第三次碰见某个数x：   0   0（把a和b都清空，可以处理其他数）

    */
    class Single_Number_II
    {
        public int SingleNumber(int[] A)
        {
            int ones = 0, twos = 0;
            for (int i = 0; i < A.Length; i++)
            {
                ones = (ones ^ A[i]) & ~twos;
                twos = (twos ^ A[i]) & ~ones;
            }
            return ones;
        }
    }
}
