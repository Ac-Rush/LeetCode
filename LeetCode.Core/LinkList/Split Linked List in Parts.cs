using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkList
{
   public class Split_Linked_List_in_Parts
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode[] SplitListToParts(ListNode root, int k)
        {
            var len = 0;
            var curt = root;
            while (curt != null)
            {
                len++;
                curt = curt.next;
            }

            var size = len/k;
            var extra = len%k;

            var result = new ListNode[k];

            for (int i = 0; i < k; i++)
            {
                if (root != null)
                {
                    var count = size + (i < extra ? 1 : 0);
                    result[i] = root;
                    for (int j = 1; j < count; j++)
                    {
                        root = root.next;
                    }
                    var next = root.next;
                    root.next = null;
                    root = next;
                }
            }
            return result;
        }
    }
}
