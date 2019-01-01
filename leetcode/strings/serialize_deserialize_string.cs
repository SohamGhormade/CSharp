
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Strings
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {

            var resultString = "";
            serializeRecursively(resultString, root);

            Console.WriteLine(resultString);
            return resultString;
        }
        // recursive serialization using preorder traversal
        private string serializeRecursively(string resultString, TreeNode root)
        {
            if (root != null)
            {
                resultString = string.Concat(resultString, root.val, ",");

                resultString = serializeRecursively(resultString, root.left);
                resultString = serializeRecursively(resultString, root.right);
            }
            else
            {
                resultString = string.Concat(resultString, "null", ",");

            }

            return resultString;
        }

        // Decodes your encoded data to tree.
        // Convert string back to TreeNode
        public TreeNode deserialize(string data)
        {
            TreeNode root = null;
            string[] data_array = data.Split(",");
            foreach(var d in data_array)
            Console.WriteLine(d);

            root = deserializeRecusively(data_array.ToList(), root);
            return root;
        }

        private TreeNode deserializeRecusively(List<string> resultList, TreeNode root)
        {
            if (resultList.ElementAt(0).Equals("null"))
            {
                root = null;
            }
            else
            {
                System.Console.WriteLine(resultList.ElementAt(0));
               // root = new TreeNode(Convert.ToInt32(resultList.ElementAt(0)));
            }
            resultList.Remove(resultList[0]);

           // root = deserializeRecusively(resultList, root.left);
           // root = deserializeRecusively(resultList, root.right);

            return root;
        }

    }

    class CodecTest
    {
        public void Run()
        {
            var root = new TreeNode(1);
            var left = new TreeNode(2);
            var right = new TreeNode(3);
            var rightChildLeft = new TreeNode(4);
            var rightChildRight = new TreeNode(5);
            root.left = left;
            root.right = right;

            right.right = rightChildRight;
            right.left = rightChildLeft;
            var codec = new Codec();
            Console.WriteLine(codec.serialize(root));
            var t = codec.deserialize(codec.serialize(root));
        //    Debug.Assert(t.val == 1);


                    }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));