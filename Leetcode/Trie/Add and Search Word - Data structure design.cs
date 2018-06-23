using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    public class WordDictionary
    {
        private readonly TrieNode root;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            root = new TrieNode();

        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (node.children[c - 'a'] == null)
                {
                    node.children[c - 'a'] = new TrieNode();
                }
                node = node.children[c - 'a'];
            }
            node.item = word;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return match(word.ToCharArray(), 0, root);
        }

        private bool match(char[] chs, int k, TrieNode node)
        {
            if (k == chs.Length) return !node.item.Equals("");
            if (chs[k] != '.')
            {
                return node.children[chs[k] - 'a'] != null && match(chs, k + 1, node.children[chs[k] - 'a']);
            }
            else
            {
                for (int i = 0; i < node.children.Length; i++)
                {
                    if (node.children[i] != null)
                    {
                        if (match(chs, k + 1, node.children[i]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public String item = "";
       
    }

}
