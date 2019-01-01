//easy



// TODO solve iteratively
//public class Solution {
    // 60% fast
//     public TreeNode InvertTree(TreeNode root) {

//         if(root==null)
//             return null;
//         //TODO corner corner cases.
//         swap(ref root.left, ref root.right);
//         return root;
//     }
//     //T:O(n)
//     // S:O(1)
//     private void swap(ref TreeNode n1,ref TreeNode n2)
//     {
//        if(n1==null && n2==null)
//             return;

//         {
//             var temp = n1;
//             n1 = n2;
//             n2 = temp;
//         }

//         if(n1!=null)
//           swap(ref n1.left, ref n1.right);

//         if(n2!=null)
//           swap(ref n2.left, ref n2.right);



//     }
namespace Trees

{
     // Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }
    public class Solution2
    {
       public TreeNode InvertTree(TreeNode root)
       {
         if (root == null)
        {
           return null;
        }
         var right = InvertTree(root.right);
        var left = InvertTree(root.left);
        root.left = right;
        root.right = left;
         return root;
     }
   }
}
    // 80 % fast --given solution from LeetCode
