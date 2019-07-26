using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Find_All_Anagrams_in_a_String
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (p.Length > s.Length) return result;

            //create a hashmap to save the Characters of the target substring.
            //(K, V) = (Character, Frequence of the Characters)
            var map = new Dictionary<char, int>();
            foreach (var c in p)
            {
                if (!map.ContainsKey(c))
                {
                    map[c] = 0;
                }
                map[c]++;
            }
            //maintain a counter to check whether match the target string.
            int counter = map.Count;//must be the map size, NOT the string size because the char may be duplicate.

            //Two Pointers: begin - left pointer of the window; end - right pointer of the window
            int begin = 0, end = 0;

            //the length of the substring which match the target string.
            int len = int.MaxValue;
            while (end < s.Length)
            {

                char c = s[end];//get a character

                if (map.ContainsKey(c))
                {
                    map[c]--;// plus or minus one
                    if (map[c] == 0) counter--;//modify the counter according the requirement(different condition).
                }
                end++;

                //increase begin pointer to make it invalid/valid again
                while (counter == 0 /* counter condition. different question may have different condition */)
                {

                    char tempc = s[begin];
                    if (map.ContainsKey(tempc))
                    {
                        map[tempc]++; ;//plus or minus one
                        if (map[tempc] > 0)
                        {
                            counter++;
                        }
                    }
                    if (end - begin == p.Length)
                    {
                        result.Add(begin);
                    }
                    /* save / update(min/max) the result if find a target*/
                    // result collections or result int value

                    begin++;
                }
            }
            return result;

           
        }

        /// <summary>
        /// 太棒了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams2(string s, string p)
        {
            List<int> list = new List<int>();
            if (s == null || s.Length == 0 || p == null || p.Length == 0) return list;
            int[] hash = new int[256]; //character hash
                                       //record each character in p to hash
            foreach (var c in p)
            {
                hash[c]++;
            }
           
            //two points, initialize count to p's length
            int left = 0, right = 0, count = p.Length;
            while (right < s.Length)
            {
                //move right everytime, if the character exists in p's hash, decrease the count
                //current hash value >= 1 means the character is existing in p
                if (hash[s[right++]]-- >= 1) count--;

                //when the count is down to 0, means we found the right anagram
                //then add window's left to result list
                if (count == 0) list.Add(left);

                //if we find the window's size equals to p, then we have to move left (narrow the window) to find the new match window
                //++ to reset the hash because we kicked out the left
                //only increase the count if the character is in p
                //the count >= 0 indicate it was original in the hash, cuz it won't go below 0
                if (right - left == p.Length && hash[s[left++]]++ >= 0) count++;
            }
            return list;
        }


        public List<int> slidingWindowTemplate(String s, String t)
        {
            //init a collection or int value to save the result according the question.
            List<int> result = new List<int>();
            if (t.Length > s.Length) return result;

            //create a hashmap to save the Characters of the target substring.
            //(K, V) = (Character, Frequence of the Characters)
            var map = new Dictionary<char,int >();
            foreach (var c in t)
            {
                if (!map.ContainsKey(c))
                {
                    map[c] = 0;
                }
                map[c]++;
            }
            //maintain a counter to check whether match the target string.
            int counter = map.Count;//must be the map size, NOT the string size because the char may be duplicate.

            //Two Pointers: begin - left pointer of the window; end - right pointer of the window
            int begin = 0, end = 0;

            //the length of the substring which match the target string.
            int len = int.MaxValue;

            //loop at the begining of the source string
            while (end < s.Length)
            {

                char c = s[end];//get a character

                if (map.ContainsKey(c))
                {
                    map[c]--;// plus or minus one
                    if (map[c] == 0) counter--;//modify the counter according the requirement(different condition).
                }
                end++;

                //increase begin pointer to make it invalid/valid again
                while (counter == 0 /* counter condition. different question may have different condition */)
                {

                    char tempc = s[begin];//***be careful here: choose the char at begin pointer, NOT the end pointer
                    if (map.ContainsKey(tempc))
                    {
                        map[tempc]++; ;//plus or minus one
                        if (map[tempc] > 0) counter++;//modify the counter according the requirement(different condition).
                    }

                    /* save / update(min/max) the result if find a target*/
                    // result collections or result int value

                    begin++;
                }
            }
            return result;
        }
    }
}
