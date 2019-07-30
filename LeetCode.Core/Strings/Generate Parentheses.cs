using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    public class Generate_Parentheses
    {

        public List<String> generateParenthesis(int n)
        {
            List<String> ans = new List<String>();
            if (n == 0)
            {
                ans.Add("");
            }
            else
            {
                for (int c = 0; c < n; ++c)
                    foreach (String left in generateParenthesis(c))
                        foreach (String right in generateParenthesis(n - 1 - c))
                            ans.Add("(" + left + ")" + right);
            }
            return ans;
        }


        public static IList<string> GenerateParenthesisMy(int n)
        {
            var result = new List<string>();
            DfsHelperMY(result,string.Empty, n,n );
            return result;
        }

        private static void DfsHelperMY(IList<string> result, string path, int left, int right)
        {
            if (left > right || left < 0 || right < 0) // my bug  第二次触发
            {
                return;
            }
            if (left == 0 && right == 0)
            {
                result.Add(path);
                return; // my bug miss return;
            }
            DfsHelperMY(result, path + '(', left - 1, right);
            DfsHelperMY(result, path + ')', left, right - 1);
        }
    }



}
