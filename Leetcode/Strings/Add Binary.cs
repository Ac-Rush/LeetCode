using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Add_Binary
    {
        /// <summary>
        /// so good 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int i = a.Length - 1, j = b.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (j >= 0) sum += b[j--] - '0';
                if (i >= 0) sum += a[i--] - '0';
                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }
            if (carry != 0) sb.Insert(0, carry);
            return  sb.ToString();
        }


        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinaryMy(string a, string b)
        {
            var aTail = a.Length - 1;
            var bTail = b.Length - 1;
            var res = 0;
            var sb = new StringBuilder();
            while (aTail >= 0 && bTail >= 0)
            {
                var result = a[aTail] - '0' + b[bTail] - '0' + res;
                char c = '\0';
                switch (result)
                {
                    case 0:
                        c = '0';
                        res = 0;
                        break;
                    case 1:
                        c = '1';
                        res = 0;
                        break;
                    case 2:
                        c = '0';
                        res = 1;
                        break;
                    case 3:
                        c = '1';
                        res = 1;
                        break;
                }
                sb.Insert(0, c);
                aTail--;
                bTail--;
            }
            while (aTail >= 0)
            {
                var result = a[aTail] - '0'  + res;
                char c = '\0';
                switch (result)
                {
                    case 0:
                        c = '0';
                        res = 0;
                        break;
                    case 1:
                        c = '1';
                        res = 0;
                        break;
                    case 2:
                        c = '0';
                        res = 1;
                        break;
                }
                sb.Insert(0, c);
                aTail--;
            }
            while (bTail >= 0)
            {
                var result = b[bTail] - '0' + res;
                char c = '\0';
                switch (result)
                {
                    case 0:
                        c = '0';
                        res = 0;
                        break;
                    case 1:
                        c = '1';
                        res = 0;
                        break;
                    case 2:
                        c = '0';
                        res = 1;
                        break;
                }
                sb.Insert(0, c);
                bTail--;
            }
            if(res == 1)
                sb.Insert(0, '1');

            return sb.ToString();
        }
    }
}
