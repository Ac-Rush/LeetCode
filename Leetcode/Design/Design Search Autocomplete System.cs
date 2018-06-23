using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class AutocompleteSystem
    {
        public class Node
        {
            public Node(String st, int t)
            {
                sentence = st;
                times = t;
            }
            public String sentence;
            public int times;
        }
        public class Trie
        {
            public int times;
            public Trie[] branches = new Trie[27];
        }
        public int int_(char c)
        {
            return c == ' ' ? 26 : c - 'a';
        }
        public void Insert(Trie t, String s, int times)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (t.branches[int_(s[i])] == null)
                    t.branches[int_(s[i])] = new Trie();
                t = t.branches[int_(s[i])];
            }
            t.times += times;
        }
        public List<Node> lookup(Trie t, String s)
        {
            List<Node> list = new List<Node>();
            for (int i = 0; i < s.Length; i++)
            {
                if (t.branches[int_(s[i])] == null)
                    return new List<Node>();
                t = t.branches[int_(s[i])];
            }
            traverse(s, t, list);
            return list;
        }
        public void traverse(String s, Trie t, List<Node> list)
        {
            if (t.times > 0)
                list.Add(new Node(s, t.times));
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (t.branches[i - 'a'] != null)
                    traverse(s + i, t.branches[i - 'a'], list);
            }
            if (t.branches[26] != null)
                traverse(s + ' ', t.branches[26], list);
        }
        Trie root;
        public AutocompleteSystem(String[] sentences, int[] times)
        {
            root = new Trie();
            for (int i = 0; i < sentences.Length; i++)
            {
                Insert(root, sentences[i], times[i]);
            }
        }
        String cur_sent = "";
        public List<String> Input(char c)
        {
            List<String> res = new List<String>();
            if (c == '#')
            {
                Insert(root, cur_sent, 1);
                cur_sent = "";
            }
            else
            {
                cur_sent += c;
                List<Node> list = lookup(root, cur_sent);
                list = list.OrderByDescending(a => a.times).ThenBy(a=>a.sentence).ToList();
               
                for (int i = 0; i < System.Math.Min(3, list.Count); i++)
                    res.Add(list[i].sentence);
            }
            return res;
        }
    }
}
