
//T:O(n) since preorder traversal
// S:? review
using System.Collections.Generic;

//Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x)
    {
        val = x;
    }

    public class Solution_Dec_16_2018_Improved_Level_Order
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            var levelToList = new Dictionary<int, List<int>>();
            preorder(root, levelToList, 0);
            // todo :avoid conversion

            foreach (var key in levelToList.Keys)
            {
                result.Add(levelToList[key]);
            }

            return result;
        }

        private void preorder(TreeNode root, Dictionary<int, List<int>> levelToList, int level)
        {
            if (root != null)
            {
                if (!levelToList.ContainsKey(level))
                {
                    var list = new List<int>();
                    list.Add(root.val);
                    levelToList.Add(level, list);

                }
                else
                {
                    levelToList[level].Add(root.val);
                }

                preorder(root.left, levelToList, level + 1);
                preorder(root.right, levelToList, level + 1);
                return;
            }
            else
            {
                return;
            }
        }
    }
}