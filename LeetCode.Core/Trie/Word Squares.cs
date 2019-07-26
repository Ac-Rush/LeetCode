using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    class Word_Squares
    {
        public class TrieNode  //这会 的trie node不一样了
        {
            public List<string> startWith;  //根据题意， 这次要求 前序相同的 字符串组，所以是这样的 node
            public TrieNode[] children;  //这个是不变的

            public TrieNode()
            {
                startWith = new List<string>();
                children = new TrieNode[26];
            }
        }
        public class Trie
        {
            public TrieNode root;

            public  Trie(String[] words)
            {
                root = new TrieNode();
                foreach (String w in words)
                {
                    TrieNode cur = root;
                    foreach (char ch in w)
                    {
                        int idx = ch - 'a';
                        if (cur.children[idx] == null)
                            cur.children[idx] = new TrieNode();  //如果没有这创建 trie node
                        cur.children[idx].startWith.Add(w);   // 加入到前缀数组里
                        cur = cur.children[idx];   //移动到孩子节点
                    }
                }
            }

            public  List<String> findByPrefix(String prefix)
            {
                TrieNode cur = root;
                foreach (char ch in prefix)
                {
                    int idx = ch - 'a';
                    if (cur.children[idx] == null)  //如果没有找到
                        return new List<string>();

                    cur = cur.children[idx];
                }
                return cur.startWith;
            }
        }

        public List<IList<String>> WordSquares(String[] words)
        {
            List<IList<String>> ans = new List<IList<String>>();
            if (words == null || words.Length == 0)  //特殊 check
                return ans;
            int len = words[0].Length;  
            Trie trie = new Trie(words);  //创建 trie树
            List<String> ansBuilder = new List<String>();
            foreach (String w in words)
            {
                //每一个树都排在第一行， 去试
                ansBuilder.Add(w);  // 暂时加入到结果
                search(len, trie, ans, ansBuilder);  //search 是否以当前 ansBuilder 可以找到 结果 
                ansBuilder.RemoveAt(ansBuilder.Count - 1);  //递归模板， 去掉这个结果 ， 以便试下一个
            }

            return ans;
        }

        private void search(int len, Trie tr, List<IList<String>> ans,
            List<String> ansBuilder)
        {
            if (ansBuilder.Count == len)  //就是当前这一次的遍历，如果 当前结果的数量 等于的 第一个单词的长度， 就找完了， 加入最终结果
            {
                ans.Add(new List<String>(ansBuilder));
                return;
            }

            int idx = ansBuilder.Count;
            StringBuilder prefixBuilder = new StringBuilder();
            foreach (var s in ansBuilder)
            {
                prefixBuilder.Append(s[idx]);  // 第 idx列的前缀
            }
            List<String> startWith = tr.findByPrefix(prefixBuilder.ToString());
            foreach (String sw in startWith)
            {
                //一个一个试
                ansBuilder.Add(sw);   //添加一个到结果里
                search(len, tr, ans, ansBuilder);  //递归调用
                ansBuilder.RemoveAt(ansBuilder.Count - 1); // 递归调用特定写法  reset
            }
        }
    }
}
