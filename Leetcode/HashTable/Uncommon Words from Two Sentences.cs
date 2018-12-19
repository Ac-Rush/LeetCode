namespace Leetcode.HashTable
{
    using System.Collections.Generic;
    public class Uncommon_Words_from_Two_Sentences
    {
         public string[] UncommonFromSentences(string A, string B) {
        var dict = new Dictionary<string ,int>();
        foreach(var w in (A+" " + B).Split(' ')){
            if(!dict.ContainsKey(w)){
                dict[w] = 0;
            }
            dict[w]++;
        }
        return dict.Keys.Where( k=> dict[k] ==1).ToArray();
        }   
    }
}