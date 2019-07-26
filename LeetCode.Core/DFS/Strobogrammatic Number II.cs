using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Strobogrammatic_Number_II
    {
        public IList<string> FindStrobogrammatic(int n)
        {
            return helper(n, n);
        }

        //n 是中间需要多少个
        //m 是一共多少个
        public List<String> helper(int n, int m)
        {
            if (n == 0) return new List<String>() { "" };
            if (n == 1) return new List<String>() { "0", "1" ,"8"};

            List<String> list = helper(n - 2, m);

            List<String> res = new List<String>();

            for (int i = 0; i < list.Count; i++)
            {
                String s = list[i];

                if (n != m) res.Add("0" + s + "0"); //因为 0 开头多余一位的是非法的 所以有这个判断。

                res.Add("1" + s + "1");
                res.Add("6" + s + "9");
                res.Add("8" + s + "8");
                res.Add("9" + s + "6");
            }

            return res;
        }
    }
}
