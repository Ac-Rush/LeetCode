using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Excel_Sheet_Column_Title
    {
        public string ConvertToTitle(int n)
        {
            return n == 0 ? "" : ConvertToTitle(--n / 26) + (char)('A' + (n % 26));
        }

        public string ConvertToTitle2(int n)
        {
            StringBuilder result = new StringBuilder();

            while (n > 0)
            {
                n--;
                result.Insert(0, (char)('A' + n % 26));
                n /= 26;
            }

            return result.ToString();
        }


        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ConvertToTitleMy(int n)
        {

            var ret = "";
            while (n > 0)
            {
                n = n - 1;  //my bug 之前没有这句
                var rest = n % 26;
                char c = (char)(rest + 'A');
                ret = c + ret;
                n = n / 26;
            }
            return ret;
        }
    }
}
