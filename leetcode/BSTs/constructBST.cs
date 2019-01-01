/*
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/
using System;
using System.Collections.Generic;
using System.Linq;
//AVOID converting array to List or Dictionaryz
namespace Trees
{
    public class ConstructBST
    {//SUPER slow !! 1128 ms
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
         if(preorder.Length == 0 && inorder.Length ==0)
            {
              return null;
            }
            return BuildTree(preorder.ToList(), inorder.ToList());

        }

        private TreeNode BuildTree(List<int> preorder, List<int> inorder)
        {
            var rootElement = preorder.FirstOrDefault();

            var root = new TreeNode(rootElement);
            preorder.Remove(rootElement);

            var inorderLeft = new List<int>();
            var inorderRight = new List<int>();
            var index = inorder.IndexOf(rootElement);

            for (var i = 0; i < inorder.Count; i++)
            {
                var element = inorder.ElementAt(i);

                if (i < index)
                    inorderLeft.Add(element);

                else if (i > index)
                    inorderRight.Add(element);// Append does not work for some reason.

            }

            if (inorderLeft.Any())
                root.left = BuildTree(preorder, inorderLeft);

            if (inorderRight.Any())
                root.right = BuildTree(preorder, inorderRight);

            return root;
        }
    }
    public class ConstructBSTTest
    {
        public void Run()
        {
            var bst = new ConstructBST();
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };
            bst.BuildTree(preorder, inorder);
        }
    }

// 124 ms --copied Java solution
    public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
    return helper(0, 0, inorder.Length - 1, preorder, inorder);
}

public TreeNode helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder) {
    if (preStart > preorder.Length - 1 || inStart > inEnd) {
        return null;
    }
    var root = new TreeNode(preorder[preStart]);
    int inIndex = 0; // Index of current root in inorder
    for (int i = inStart; i <= inEnd; i++) {
        if (inorder[i] == root.val) {
            inIndex = i;
        }
    }
    root.left = helper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
    root.right = helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);
    return root;
}
    }

}