using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Bulls_and_Cows
    {
        public string GetHint(string secret, string guess)
        {
            int bulls = 0;
            int cows = 0;
            int[] numbers = new int[10];
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i]) bulls++;
                else
                {
                    if (numbers[secret[i] - '0']++ < 0) cows++;
                    if (numbers[guess[i] - '0']-- > 0) cows++;
                }
            }
            return bulls + "A" + cows + "B";
        }
    }
}
