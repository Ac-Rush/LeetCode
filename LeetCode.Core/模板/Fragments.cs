using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.模板
{
    class Fragments
    {
        private void OrderList()
        {
            var num = 0;
            List<double> llistSlid = new List<double>(); // k的数组
            int liIndex = llistSlid.BinarySearch(num);  //二分查找
            if (liIndex < 0)
            {
                liIndex = ~liIndex;  //  liIndex = -liIndex - 1;
            }
            llistSlid.Insert(liIndex,num); // 有序插入
        }
    }
}
