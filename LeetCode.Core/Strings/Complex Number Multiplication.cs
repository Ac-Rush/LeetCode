using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Complex_Number_Multiplication
    {
        public string ComplexNumberMultiply(string a, string b)
        {
            var x = a.Split(new []{'+', 'i'});
            var y = b.Split(new[] { '+', 'i' });
            int a_real = int.Parse(x[0]);
            int a_img = int.Parse(x[1]);
            int b_real = int.Parse(y[0]);
            int b_img = int.Parse(y[1]);
            return (a_real * b_real - a_img * b_img) + "+" + (a_real * b_img + a_img * b_real) + "i";
        }
    }
}
