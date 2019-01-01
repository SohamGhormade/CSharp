/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
 // easy
 // T:
 // S:
 // TODO iterative pre-order ?
 using System.Collections.Generic;
using System.Linq;
using System.Text;
 namespace Trees

 {
    public class Solution1 {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        var pList = new List<int?>();
        var qList = new List<int?>();
        preorder(p,ref pList );
        preorder(q, ref qList);

        return pList.SequenceEqual(qList);
    }
    private void preorder(TreeNode p, ref List<int?> order)
    {
        if(p!=null)
        {
            order.Add(p.val);
            preorder(p.left, ref order);
            preorder(p.right, ref order);
        }
        else
        {
            order.Add(null);
            return;

        }
    }
}

 }
