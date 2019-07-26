using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    public class MapSum
    {
        MapSumNode root;
        Dictionary<string, int> latestValue;
        /** Initialize your data structure here. */
        public MapSum()
        {
            root = new MapSumNode();
            latestValue = new Dictionary<string, int>();
        }

        public void Insert(string key, int val)
        {
            int newValue = val;
            if (latestValue.ContainsKey(key))
            {
                newValue = val - latestValue[key];//diff
                latestValue[key] = val;
            }
            else
                latestValue.Add(key, val);
            root.Insert(key, newValue);
        }

        public int Sum(string prefix)
        {
            return root.SumOfPrefix(prefix);
        }
    }
    public class MapSumNode
    {
        public Dictionary<char, MapSumNode> Children;
        public int currSum;
        public char c;
        public MapSumNode()
        {
            Children = new Dictionary<char, MapSumNode>();
        }
        public MapSumNode(char ch)
        {
            Children = new Dictionary<char, MapSumNode>();
            currSum = 0;
            c = ch;
        }

        public void Insert(string s, int value)
        {
            Dictionary<char, MapSumNode> currChildren = Children;

            for (int i = 0; i < s.Length; i++)
            {
                MapSumNode temp;

                if (currChildren.ContainsKey(s[i]))
                {
                    temp = currChildren[s[i]];
                }
                else
                {
                    temp = new MapSumNode(s[i]);
                    currChildren.Add(s[i], temp);
                }
                temp.currSum += value;
                currChildren = temp.Children;
            }
        }

        public int SumOfPrefix(string prefix)
        {
            Dictionary<char, MapSumNode> currChildren = Children;
            int result = 0;

            for (int i = 0; i < prefix.Length; i++)
            {
                if (!currChildren.ContainsKey(prefix[i])) return 0;

                MapSumNode currNode = currChildren[prefix[i]];
                result = currNode.currSum;
                currChildren = currNode.Children;
            }

            return result;
        }
    }
}
