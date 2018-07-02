using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Palindrome_Pairs
    {
        public class TrieNode
        {
            public TrieNode[] next;
            public int index;
            public List<int> list;

            public TrieNode()
            {
                next = new TrieNode[26];
                index = -1;
                list = new List<int>();
            }
        }
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var res = new List<IList<int>>();

            TrieNode root = new TrieNode();
            for (int i = 0; i < words.Length; i++) addWord(root, words[i], i);
            for (int i = 0; i < words.Length; i++) search(words, i, root, res);

            return res;
        }
        /// <summary>
        /// 倒着加进去
        /// </summary>
        /// <param name="root"></param>
        /// <param name="word"></param>
        /// <param name="index"></param>
        private void addWord(TrieNode root, string word, int index)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                int j = word[i] - 'a';
                if (root.next[j] == null) root.next[j] = new TrieNode();
                if (isPalindrome(word, 0, i)) root.list.Add(index);
                root = root.next[j];
            }

            root.list.Add(index);
            root.index = index;
        }
        //正着找
        private void search(String[] words, int i, TrieNode root, List<IList<int>> res)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (root.index >= 0 && root.index != i && isPalindrome(words[i], j, words[i].Length - 1))
                {
                    res.Add(new List<int>() {i, root.index});
                }

                root = root.next[words[i][j] - 'a'];
                if (root == null) return;
            }

            foreach (int j in root.list)
            {
                if (i == j) continue;
                res.Add(new List<int>() {i,j});
            }
        }

        private bool isPalindrome(String word, int i, int j)
        {
            while (i < j)
            {
                if (word[i++] != word[j--]) return false;
            }

            return true;
        }
    }
}
