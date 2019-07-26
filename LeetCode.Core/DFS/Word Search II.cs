using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    // trie 树
    class Word_Search_II
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            var ret = new List<string>();
            TrieNode root = buildTrie(words);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    dfs(board, i, j, root, ret);
                }
            }
            return ret;
        }
        //dfs 遍历，
        public void dfs(char[,] board, int i, int j, TrieNode p, List<String> res)
        {
            char c = board[i,j];
            if (c == '#' || p.next[c - 'a'] == null) return;
            p = p.next[c - 'a'];
            if (p.word != null)
            {   // found one
                res.Add(p.word);
                p.word = null;     // de-duplicate
            }

            board[i,j] = '#';
            if (i > 0) dfs(board, i - 1, j, p, res);
            if (j > 0) dfs(board, i, j - 1, p, res);
            if (i < board.GetLength(0) - 1) dfs(board, i + 1, j, p, res);
            if (j < board.GetLength(1) - 1) dfs(board, i, j + 1, p, res);
            board[i,j] = c;
        }
        //构建 trie树
        public TrieNode buildTrie(String[] words)
        {
            TrieNode root = new TrieNode();
            foreach (String w in words)
            {
                TrieNode p = root;
                foreach (char c in w)
                {
                    int i = c - 'a';
                    if (p.next[i] == null) p.next[i] = new TrieNode();
                    p = p.next[i];
                }
                p.word = w;
            }
            return root;
        }
        //trie树定义
        public  class TrieNode
        {
            public TrieNode[] next = new TrieNode[26];
            public String word;
        }
    }

    //my solution 超时了， 调用了 "word seach"方法， 用 hashset去重
    class Word_Search_my
    {

        public IList<string> FindWords(char[,] board, string[] words)
        {
            var ret = new HashSet<string>();
            foreach (var word in words)
            {
                if (Exist(board, word))
                {
                    ret.Add(word);
                }
            }
            return ret.ToList();
        }

        public bool Exist(char[,] board, string word)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (DFS(board, word, 0, i, j)) return true;
                }
            }
            return false;
        }

        private bool DFS(char[,] board, string word, int index, int r, int c)
        {
            if (index == word.Length) return true;  //先这个判断， 因为如果刚好在边界结尾， 需要这样的判断， 要不然还得特殊处理
            if (r < 0 || c < 0 || r == board.GetLength(0) || c == board.GetLength(1)) return false; //然后再这个判断，
            if (board[r, c] != word[index]) return false;
            board[r, c] ^= (char)256;   // 这样就可以不用走重
            var hasWord = DFS(board, word, index + 1, r - 1, c) ||
             DFS(board, word, index + 1, r + 1, c) ||
             DFS(board, word, index + 1, r, c - 1) ||
             DFS(board, word, index + 1, r, c + 1);
            board[r, c] ^= (char)256;  //reset
            return hasWord;
        }
    }
}
