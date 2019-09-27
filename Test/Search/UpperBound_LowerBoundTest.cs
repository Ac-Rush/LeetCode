using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Core.模板;

namespace Test.Search
{
    public class UpperBound_LowerBoundTest
    {
        public  void  Test()
        {
            var array = new int[] { 2,4,6,6,6,6,8,10 };
            Console.WriteLine(UpperLowerBound.LowerBound(array, 6));
            Console.WriteLine(UpperLowerBound.UperBound(array, 6));
            Console.WriteLine(UpperLowerBound.LowerBound(array, 0));
            Console.WriteLine(UpperLowerBound.UperBound(array, 0));
            Console.WriteLine(UpperLowerBound.LowerBound(array, 20));
            Console.WriteLine(UpperLowerBound.UperBound(array, 20));
            Console.WriteLine(UpperLowerBound.LowerBound(array, 10));
            Console.WriteLine(UpperLowerBound.UperBound(array, 10));
        }
    }
}
