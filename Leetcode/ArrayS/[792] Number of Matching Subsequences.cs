using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class _792__Number_of_Matching_Subsequences
    {
        /// <summary>
      //  https://leetcode.com/problems/number-of-matching-subsequences/discuss/117634/Efficient-and-simple-go-through-words-in-parallel-with-explanation
/**
 * 
 * 
 * Runtime is linear in the total size of the input (S and all of words).
Explanation below the code.

Solutions:
Variations of the same algorithm described at the end.
 */
/// </summary>
/// <param name="S"></param>
/// <param name="words"></param>
/// <returns></returns>
/// 
/**
 * 
 * 
 * 
 * 
 * I go through S once, and while I'm doing that, I move through all words accordingly. That is, I keep track of how much of each word I've already seen, and with each letter of S, I advance the words waiting for that letter. To quickly find the words waiting for a certain letter, I store each word (and its progress) in a list of words waiting for that letter. Then for each of the lucky words whose current letter just occurred in S, I update their progress and store them in the list for their next letter.

Let's go through the given example:

S = "abcde"
words = ["a", "bb", "acd", "ace"]
I store that "a", "acd" and "ace" are waiting for an 'a' and "bb" is waiting for a 'b' (using parentheses to show how far I am in each word):

'a':  ["(a)", "(a)cd", "(a)ce"]
'b':  ["(b)b"]
Then I go through S. First I see 'a', so I take the list of words waiting for 'a' and store them as waiting under their next letter:

'b':  ["(b)b"]
'c':  ["a(c)d", "a(c)e"]
None: ["a"]
You see "a" is already waiting for nothing anymore, while "acd" and "ace" are now waiting for 'c'. Next I see 'b' and update accordingly:

'b':  ["b(b)"]
'c':  ["a(c)d", "a(c)e"]
None: ["a"]
Then 'c':

'b':  ["b(b)"]
'd':  ["ac(d)"]
'e':  ["ac(e)"]
None: ["a"]
Then 'd':

'b':  ["b(b)"]
'e':  ["ac(e)"]
None: ["a", "acd"]
Then 'e':

'b':  ["b(b)"]
None: ["a", "acd", "ace"]
And now I just return how many words aren't waiting for anything anymore.



    */
public int NumMatchingSubseq(string S, string[] words)
{
    List<int[]>[] waiting = new List<int[]>[128];
    for (int c = 0; c <= 'z'; c++)
        waiting[c] = new List<int[]>();
    for (int i = 0; i < words.Length; i++)
        waiting[words[i][0]].Add(new int[] { i, 1 });
    foreach (char c in S)
    {
        List<int[]> advance = new List<int[]>(waiting[c]);
        waiting[c].Clear();
        foreach (int[] a in advance)
            waiting[a[1] < words[a[0]].Length ? words[a[0]] [a[1]++] : 0].Add(a);
    }
    return waiting[0].Count;
}

        /// <summary>
        /// ，解法类似消消乐
        /// </summary>
        /// <param name="S"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int NumMatchingSubseq2(string S, string[] words)
        {
            Dictionary<char, List<string>> map = new Dictionary<char, List<string>>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                map[c] = new List<string>();
            }
            foreach (String word in words)
            {
                map[word[0]].Add(word);
            }

            int count = 0;
            foreach (char c in S)
            {
                var queue = map[c];
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    String word = queue.First(); // was my bug
                    queue.RemoveAt(0);
                    if (word.Length == 1)
                    {
                        count++;
                    }
                    else
                    {
                        map[word[1]].Add(word.Substring(1));
                    }
                }
            }
            return count;
        }
}
}
