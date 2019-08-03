using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    internal abstract class NestedInteger
    {
        public NestedInteger()
        {
            throw new NotImplementedException();
        }

        public NestedInteger(int value)
        {
            throw new NotImplementedException();
        }

        public abstract bool IsInteger();
        public abstract int GetInteger();
        public abstract void SetInteger(int value);
        public abstract void Add(NestedInteger ni);
        public abstract IList<NestedInteger> GetList();
    }

    class Nested_List_Weight_Sum
    {
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            return helper(nestedList, 1);
        }
        private int helper(IList<NestedInteger> list, int depth)
        {
            int ret = 0;
            foreach (NestedInteger e in list)
            {
                ret += e.IsInteger() ? e.GetInteger() * depth : helper(e.GetList(), depth + 1);
            }
            return ret;
        }
    }
}
