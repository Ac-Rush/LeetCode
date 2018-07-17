using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Decode_String
    {
        


        public string DecodeString2(string s)
        {
            String res = "";
            Stack<int> countStack = new Stack<int>();  //数字的stack
            Stack<String> resStack = new Stack<string>();  //string的 stack
            int idx = 0;
            while (idx < s.Length)
            {
                if (char.IsDigit(s[idx]))   //如果是数
                {
                    int count = 0;
                    while (char.IsDigit(s[idx]))
                    {
                        count = 10 * count + (s[idx] - '0');
                        idx++;
                    }
                    countStack.Push(count); //入栈
                }
                else if (s[idx] == '[')
                {
                    resStack.Push(res);  //如果是左边 入栈 str
                    res = "";
                    idx++;
                }
                else if (s[idx] == ']')  //如果是右边  出站 str count
                {
                    StringBuilder temp = new StringBuilder(resStack.Pop());
                    int repeatTimes = countStack.Pop();
                    for (int i = 0; i < repeatTimes; i++)
                    {
                        temp.Append(res);
                    }
                    res = temp.ToString();
                    idx++;
                }
                else
                {
                    res += s[idx++];
                }
            }
            return res;
        }
    }

    public class Decode_String_DFS
    {
        public string DecodeString(string s)
        {
            int i = 0;
            return DecodeString(s, ref i);
        }

        private string DecodeString(string s, ref int i)
        {
            string res = "";

            while (i < s.Length && s[i] != ']')  //右括号退出
            {
                if (!char.IsDigit(s[i]))
                    res += s[i++];
                else
                {
                    int n = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                        n = n * 10 + s[i++] - '0';

                    i++; // '['
                    string t = DecodeString(s,ref i);
                    i++; // ']'

                    while (n-- > 0)
                        res += t;
                }
            }

            return res;
        }

    }
}
