using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Replace_Words
    {
        /// <summary>
        /// Approach #1: Prefix Hash [Accepted]
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var rootset = new HashSet<string>();
            foreach (String root in dict) rootset.Add(root);

            StringBuilder ans = new StringBuilder();
            foreach (String word in sentence.Split(' '))
            {
                String prefix = "";
                for (int i = 1; i <= word.Length; ++i)
                {
                    prefix = word.Substring(0, i);
                    if (rootset.Contains(prefix)) break;
                }
                if (ans.Length > 0) ans.Append(" ");
                ans.Append(prefix);
            }
            return ans.ToString();
        }

       
        /// <summary>
        /// Approach #2: Trie [Accepted]
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords2(IList<string> dict, string sentence)
        {
            TrieNode trie = new TrieNode();
            foreach (String root in dict)
            {
                TrieNode cur = trie;
                foreach (char letter in root)
                {
                    if (cur.Children[letter - 'a'] == null)
                        cur.Children[letter - 'a'] = new TrieNode();
                    cur = cur.Children[letter - 'a'];
                }
                cur.Word = root;
            }

            StringBuilder ans = new StringBuilder();

            foreach (String word in sentence.Split(' '))
            {
                if (ans.Length > 0) ans.Append(" ");

                TrieNode cur = trie;
                foreach (char letter in word)
                {
                    if (cur.Children[letter - 'a'] == null || cur.Word != null)
                        break;
                    cur = cur.Children[letter - 'a'];
                }
                ans.Append(cur.Word != null ? cur.Word : word);
            }
            return ans.ToString();
        }
    }
    public class TrieNode
    {
        public TrieNode[] Children;
        public String Word;
        public TrieNode()
        {
            Children = new TrieNode[26];
        }
    }
}
