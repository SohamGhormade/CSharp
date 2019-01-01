using System.Collections.Generic;
using System.Linq;
public class Solution_Level_Order{
    public IList<IList<int>> LevelOrder(TreeNode root) {

         var arr = new List<IList<int>>();

        if(root == null)
            return arr;


        arr.Add(new List<int>());

        traversal(root,ref arr, 0);

        return arr;
    }

    private void traversal(TreeNode root, ref List<IList<int>> arr, int level)
    {
        if(root != null)
            arr.ElementAt(level).Add(root.val);
         else
             return;
        if(root.left!=null || root.right !=null)

        { if(level+1 == arr.Count)
            arr.Add(new List<int>());
        }
        traversal(root.left, ref arr, level + 1);
        traversal(root.right, ref arr, level + 1);

    }

}