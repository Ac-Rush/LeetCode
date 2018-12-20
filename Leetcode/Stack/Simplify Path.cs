using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Simplify_Path
    {
        public string SimplifyPath(string path)
        {
            string[] pathDir = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < pathDir.Length; i++)
            {
                if (pathDir[i] == ".") continue;
                if (pathDir[i] == "..")
                {
                    if (stack.Count != 0)
                        stack.Pop();
                    continue;
                }
                stack.Push(pathDir[i]);
            }
            string res = string.Empty;
            while (stack.Count != 0)
                res = "/" + stack.Pop() + res;
            return res.Length == 0 ? "/" : res;

        }
    }
}
