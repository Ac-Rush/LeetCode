using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    class Next_Greater_Element_III
    {
        /// <summary>
        /// 太牛了，
        ///  1. 从最右边找到第一个 降序的   i
        /// 2.  从右向左找到最后一个比这个大的  j
        /// 3. 交换 i,j
        /// 4翻转 i+1后边的书， 升序最小
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextGreaterElement(int n)
        {
            char[] a = ("" + n).ToCharArray();
            int i = a.Length - 2;
            while (i >= 0 && a[i + 1] <= a[i]) //1. 从最右边找到第一个 降序的  i
            {
                i--;
            }
            if (i < 0)
                return -1;
            int j = a.Length - 1;
            while (j >= 0 && a[j] <= a[i]) //2. 从右向左找到最后一个比这个大的  j
            {
                j--;
            }
            swap(a, i, j); //3.交换 i,j
            reverse(a, i + 1);  //4翻转 i+1后边的书， 升序最小
            try
            {
                return int.Parse(new String(a));  // 越界溢出check
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        private void reverse(char[] a, int start)
        {
            int i = start, j = a.Length - 1;
            while (i < j)
            {
                swap(a, i, j);
                i++;
                j--;
            }
        }
        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
