using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    class MyHashSet
    {
        /** Initialize your data structure here. */
        const int SIZE = 1000001;
        public bool[] Numbers { get; set; }


        /** Initialize your data structure here. */
        public MyHashSet()
        {
            Numbers = new bool[SIZE];
        }

        public void Add(int key)
        {
            if (key < 0 || key > SIZE)
                return;

            Numbers[key] = true;
        }

        public void Remove(int key)
        {
            if (key < 0 || key > SIZE)
                return;

            Numbers[key] = false;
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            if (key < 0 || key > SIZE)
                return false;

            return Numbers[key];
        }
    }
}
