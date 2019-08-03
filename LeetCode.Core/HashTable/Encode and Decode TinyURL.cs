using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Encode_and_Decode_TinyURL
    {
        List<String> urls = new List<String>();
        public string encode(string longUrl)
        {
            urls.Add(longUrl);
            return (urls.Count - 1).ToString();
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            int index = int.Parse(shortUrl);
            return (index < urls.Count) ? urls[index] : "";
        }
    }
}
