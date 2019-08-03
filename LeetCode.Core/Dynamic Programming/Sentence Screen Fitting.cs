using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Sentence_Screen_Fitting_2
    {
        public int WordsTyping(string[] sentence, int rows, int cols)
        {
            String s = String.Join(" ", sentence) + " ";
            int start = 0, l = s.Length;
            for (int i = 0; i < rows; i++)
            {
                start += cols;
                if (s[start % l] == ' ')
                {
                    start++;
                }
                else
                {
                    while (start > 0 && s[(start - 1) % l] != ' ')
                    {
                        start--;
                    }
                }
            }

            return start / s.Length;
        }
    }

    class Sentence_Screen_Fitting_DP
    {
        /*
      It's kind of like a jump game. I use a array to record for each word, how far it can jump.
eg. dp[index] means if the row start at index then the start of next row is dp[index].
dp[index] can be larger than the length of the sentence, in this case, one row can span multiple sentences.
I comment the check whether a word is longer than the row since there is no such test case. But it's better to check it. And it make little difference to the speed.   
    */
        public int WordsTyping(string[] sentence, int rows, int cols)
        {
            int[] dp = new int[sentence.Length];
            int n = sentence.Length;
            for (int i = 0, prev = 0, len = 0; i < sentence.Length; ++i)
            {
                // remove the length of previous word and space
                if (i != 0 && len > 0) len -= sentence[i - 1].Length + 1;
                // calculate the start of next line.
                // it's OK the index is beyond the length of array so that 
                // we can use it to count how many words one row has.
                while (len + sentence[prev % n].Length <= cols) len += sentence[prev++ % n].Length + 1;
                dp[i] = prev;
            }
            int count = 0;
            for (int i = 0, k = 0; i < rows; ++i)
            {
                // count how many words one row has and move to start of next row.
                // It's better to check if d[k] == k but I find there is no test case on it. 
                // if(dp[k] == k) return 0;
                count += dp[k] - k;
                k = dp[k] % n;
            }
            // divide by the number of words in sentence
            return count / n;
        }
    }
}
