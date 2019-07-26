using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class MyHashMap
    {
        /** Initialize your data structure here. */
        const int SIZE = 1000001;
        public int[] Numbers { get; set; }
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            Numbers = new int[SIZE];
            for (int i = 0; i < 1000001; i++)
            {
                Numbers[i] = -1;
            }
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            Numbers[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return Numbers[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            Numbers[key] = -1;
        }
    }
}
