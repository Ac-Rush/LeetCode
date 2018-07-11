using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    /// <summary>
    /// 太棒了，我的答案 一次过， 用 stack去模拟
    /// </summary>
    public class NestedIterator
    {
        public abstract class NestedInteger
        {
            public abstract bool IsInteger();
            public abstract int GetInteger();
            public abstract IList<NestedInteger> GetList();
        }

        private Stack<NestedInteger> NestedStack;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            NestedStack = new Stack<NestedInteger>();
            for (int i = nestedList.Count - 1; i >= 0; i--)
            {
                NestedStack.Push(nestedList[i]);
            }
        }

        public bool HasNext()
        {
            while (NestedStack.Any())
            {
                var peek = NestedStack.Peek();
                if (peek.IsInteger())
                {
                    return true;
                }
                else
                {
                    var list = NestedStack.Pop().GetList();
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        NestedStack.Push(list[i]);
                    }
                }
            }
            return false;
        }

        public int Next()
        {
            while (NestedStack.Any())
            {
                var top = NestedStack.Pop();
                if (top.IsInteger())
                {
                    return top.GetInteger();
                }
                else
                {
                    var list = top.GetList();
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        NestedStack.Push(list[i]);
                    }
                }
            }
            return 0;
        }
    }
}
