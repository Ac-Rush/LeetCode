﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    /*
     * Consider a node in the tree.
It can be covered by its parent, itself, its two children.
Four options.

Consider the root of the tree.
It can be covered by left child, or right child, or itself.
Three options.

Consider one leaf of the tree.
It can be covered by its parent or by itself.
Two options.

If we set a camera at the leaf, the camera can cover the leaf and its parent.
If we set a camera at its parent, the camera can cover the leaf, its parent and its sibling.

We can see that the second plan is always better than the first.
Now we have only one option, set up camera to all leaves' parent.

Here is our greedy solution:

Set cameras on all leaves' parents, thenremove all covered nodes.
Repeat step 1 until all nodes are covered.
Explanation:
Apply a recusion function dfs.
Return 0 if it's a leaf.
Return 1 if it's a parent of a leaf, with a camera on this node.
Return 2 if it's coverd, without a camera on this node.

For each node,
if it has a child, which is leaf (node 0), then it needs camera.
if it has a child, which is the parent of a leaf (node 1), then it's covered.

If it needs camera, then res++ and we return 1.
If it's covered, we return 2.
Otherwise, we return 0.
     */
    class Binary_Tree_Cameras
    {
        int res = 0;
        public int MinCameraCover(TreeNode root)
        {
            return (Dfs(root) < 1 ? 1 : 0) + res;
        }

        /*
         *
Return 0 if it's a leaf.
Return 1 if it's a parent of a leaf, with a camera on this node. // 1的位置放了相机
Return 2 if it's coverd, without a camera on this node.
         */
        public int Dfs(TreeNode root)
        {
            if (root == null) return 2;  // 这个值
            int left = Dfs(root.left), right = Dfs(root.right);
            if (left == 0 || right == 0)
            {
                res++;
                return 1;
            }
            //如果左右孩子放了相机 就是2 coverd了， 否则就是一个leaf
            return left == 1 || right == 1 ? 2 : 0;
        }
    }
}
