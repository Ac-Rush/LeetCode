using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Similar_RGB_Color
    {
        public string SimilarRGB(string color)
        {
            return "#" + f(color.Substring(1, 2)) + f(color.Substring(3, 2)) + f(color.Substring(5));
        }

        public string f(string comp)
        {
            int q = Convert.ToInt32(comp, 16);
            q = q / 17 + (q % 17 > 8 ? 1 : 0);
            return string.Format("{0:x2}", 17 * q);
        }
    }
}
