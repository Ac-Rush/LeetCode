using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
    class Reverse_Nodes_in_k_Group
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            { // find the k+1 node
                curr = curr.next;
                count++;
            }
            if (count == k)
            { // if k+1 node is found
                curr = ReverseKGroup(curr, k); //递归后半段// reverse list with k+1 node as head
                                               // head - head-pointer to direct part, 
                                               // curr - head-pointer to reversed part;
                while (count-- > 0) //反转前k个
                { // reverse current k-group: 
                    ListNode tmp = head.next; // tmp - next head in direct part
                    head.next = curr; // preappending "direct" head to the reversed list 
                    curr = head; // move head of reversed part to a new node
                    head = tmp; // move "direct" head to the next node in direct part
                }
                head = curr;
            }
            return head;
        }
    }
}
