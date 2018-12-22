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



        如果是出现两次的话，用一个bit就可以
    比如 b，初始为0
    当5第1次出现时， b=5
    当5第2次出现是， b清空为0，表示b可以去处理其他数字了
    所以，最后 如果 b !=0的话，b记录的就是只出现了一次的那个数字
    
    ->公式就是 b = b xor i  或者 b = b^i


    那么，如果是三次的话，香浓定理，需要用2bits进行记录

    当5第一次出现的时候，b = 5, a=0,  b记录这个数字
    当5第二次出现的时候，b = 0, a=5， a记录了这个数字
    当5第三次出现的时候，b = 0, a=0， 都清空了，可以去处理其他数字了
    所以，如果有某个数字出现了1次，就存在b中，出现了两次，就存在a中，所以返回 a|b

    公式方面 ，上面两次的时候，b清空的公式是 b = b xor i
            而第三次时，b要等于零，而这时a是True，所以再 & 一个a的非就可以，b = b xor & ~a
    -> b = b xor i & ~ a
       a = a xor i & ~b


    */
    class Single_Number_II
    {
        public int SingleNumber(int[] A)
        {
            int ones = 0, twos = 0;
            foreach (var t in A)
            {
                ones = (ones ^ t) & ~twos;
                twos = (twos ^ t) & ~ones;
            }
            return ones;
        }
    }


    class Single_Number_II_2
    {
        public int SingleNumber(int[] A)
        {
            int[] bit_time = new int[32];
            int i = 0;
            int j = 0;
            int result = 0;
            for (i = 0; i < 32; i++)
            {
                for (j = 0; j < A.Length; j++)
                {
                    bit_time[i] += (A[j] >> i) & 0x01;
                }
                result |= (bit_time[i] % 3) << i;
            }
            return result;
        }
    }
}
