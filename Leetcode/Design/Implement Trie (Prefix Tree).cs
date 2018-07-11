using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    /// <summary>
    /// 太棒了，我的答案一次过
    /// 这个用在 auto complete  1. Autocomplete 2. Spell checker 3. IP routing (Longest prefix matching)
    /// 4. T9 predictive text 5. Solving word games
    /// </summary>
    class Implement_Trie__Prefix_Tree_
    {
        public class Trie
        {
            private class TrieNode
            {
                public TrieNode[] Children = new TrieNode[26];
                public bool Compelete;
                public List<string> StartWith = new List<string>();

                public TrieNode()
                {
                }
                public TrieNode(bool compelete, List<string> startWith, TrieNode[] children)
                {
                    Compelete = compelete;
                    StartWith = startWith;
                    Children = children;
                }
            }

            private TrieNode _root;

            /** Initialize your data structure here. */
            public Trie()
            {
                _root = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var curt = _root;
                foreach (var c in word)
                {
                    if (curt.Children[c - 'a'] == null)
                    {
                        curt.Children[c - 'a'] = new TrieNode();
                    }
                    curt = curt.Children[c - 'a'];
                    curt.StartWith.Add(word);
                }
                curt.Compelete = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var curt = _root;
                foreach (var c in word)
                {
                    if (curt.Children[c - 'a'] == null)
                    {
                        return false;
                    }
                    curt = curt.Children[c - 'a'];
                }
                return curt.Compelete;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var curt = _root;
                foreach (var c in prefix)
                {
                    if (curt.Children[c - 'a'] == null)
                    {
                        return false;
                    }
                    curt = curt.Children[c - 'a'];
                }
                //这里没有必要  return ture就可以， 这样做 可以求出 prefix list 用于解题 比如 string魔方的问题
                return curt.StartWith.Any();
            }
        }
    }
}
