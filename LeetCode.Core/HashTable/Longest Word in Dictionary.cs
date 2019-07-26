using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Longest_Word_in_Dictionary
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord2(string[] words)
        {
            var set = new HashSet<string>();
            foreach (var word in words)
            {
                set.Add(word);
            }
            var len = 0;
            string result = null;
            foreach (var word in words)
            {
                var str = "";
                var allMatch = true;
                foreach (var c in word)
                {
                    str = str + c;
                    if (!set.Contains(str))
                    {
                        allMatch = false;
                        break;
                    }
                }
                if (allMatch)
                {
                    if (len < word.Length)
                    {
                        len = word.Length;
                        result = word;
                    }else if (len == word.Length && word.CompareTo(result) < 0)
                    {
                        result = word;
                    }
                }
            }
            return result;
        }
        public string LongestWord(String[] words)
        {
            Trie trie = new Trie();
            int index = 0;
            foreach (String word in words)
            {
                trie.insert(word, ++index); //indexed by 1
            }
            trie.words = words;
            return trie.dfs();
        }
    }
    class Node
    {
        public char c;
        public Dictionary<char, Node> children = new Dictionary<char, Node>();
        public int end;
        public Node(char c)
        {
            this.c = c;
        }
    }

    class Trie
    {
        public Node root;
        public String[] words;
        public Trie()
        {
            root = new Node('0');
        }

        public void insert(String word, int index)
        {
            Node cur = root;
            foreach (char c in word)
            {
                if (!cur.children.ContainsKey(c))
                {
                    cur.children[c]= new Node(c);
                }
               
                cur = cur.children[c];
            }
            cur.end = index;
        }

        public String dfs()
        {
            String ans = "";
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count>0)
            {
                Node node = stack.Pop();
                if (node.end > 0 || node == root)
                {
                    if (node != root)
                    {
                        String word = words[node.end - 1];
                        if (word.Length > ans.Length ||
                                word.Length == ans.Length && word.CompareTo(ans) < 0)
                        {
                            ans = word;
                        }
                    }
                    foreach (Node nei in node.children.Values)
                    {
                        stack.Push(nei);
                    }
                }
            }
            return ans;
        }
    }
}
