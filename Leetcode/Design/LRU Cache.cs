using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
   /// <summary>
   ///  用hashtable 加上双向链表 + 头尾假节点
   /// </summary>
    public class LRUCacheC
    {
        public class Node
        {
            public int key;
            public int value;
            public Node pre;
            public Node next;

            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private Dictionary<int, Node> Cache;  //<key, prev node>

        private int Capacity, Count;
        private Node Head, Tail;  //两个假的节点

        public LRUCacheC(int capacity)
        {
            Capacity = capacity;
            Cache = new Dictionary<int, Node>();
            Head = new Node(0, 0);
            Tail = new Node(0, 0);
            Head.next = Tail;
            Tail.pre = Head;
            Head.pre = null;
            Tail.next = null;
            Count = 0;
        }

        /// <summary>
        /// 如果存在， 需要将它删除并插入队头
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Get(int key)
        {
            if (Cache.ContainsKey(key))
            {
                Node node = Cache[key];
                int result = node.value;
                deleteNode(node);
                addToHead(node);
                return result;
            }
            return -1;
        }


       /// <summary>
       /// 1 如果存在，得到node, 修改值， 删除 node,插入队头
       /// 2.如果不存在
       ///      1）如果没满，  count++ ,插入对头
       ///      2)满了， 删除队尾， 插入队头， hashtable也要删除
       /// </summary>
       /// <param name="key"></param>
       /// <param name="value"></param>
        public void Put(int key, int value)
        {
            if (Cache.ContainsKey(key))
            {
               
                Node node = Cache[key];
                node.value = value;
                deleteNode(node);
                addToHead(node);
            }
            else
            {
                Node node = new Node(key, value);
                Cache[key] = node;
                if (Count < Capacity)
                {
                    Count++;
                    addToHead(node);
                }
                else
                {
                    Cache.Remove(Tail.pre.key);
                    deleteNode(Tail.pre);
                    addToHead(node);
                }
            }

        }

        public void deleteNode(Node node)
        {
            node.pre.next = node.next;
            node.next.pre = node.pre;
        }

        public void addToHead(Node node)
        {
            node.next = Head.next;
            node.next.pre = node;
            node.pre = Head;
            Head.next = node;
        }
    }
}
