using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Can_Place_Flowers
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            var seeOne = false;
            var count = 0;
            var sum = 0;

            foreach (int t in flowerbed)
            {
                if (t == 0)
                {
                    count++;
                }
                else
                {
                    if (!seeOne)
                    {
                        sum += count/2;
                        seeOne = true;
                    }
                    else
                    {
                        sum += (count-1) / 2;
                    }
                }
                count = 0;
            }
            sum += seeOne? count / 2 : (count+1)/2;
            return sum >=n;
        }


        public bool canPlaceFlowers2(int[] flowerbed, int n)
        {
            int i = 0, count = 0;
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i++] = 1; //边走边设置
                    count++;
                }
                if (count >= n)
                    return true;
                i++;
            }
            return false;
        }
    }
}
