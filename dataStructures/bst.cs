using System;
//Implement BST in C#.
// 12 mins + (delete impl)for code
// 30 mins +(delete impl) for whiteboard
//Remember for C# ,you cannot compare template types without the types themselves implementing
// CompareTo() on IComparable.
// Works fine
public class BST<T> where T:IComparable
{
    private class Node
    {
        public T data;
        public Node left,right;
    }

    private Node root;
    private int n;
    public void insert(T v)
    {
        insert(v,ref root);
    }

    private void insert(T v,ref Node root)
    {
        if(root== null)
        {
            root = new Node();
            root.data = v;
            root.left = root.right = null;
            n++;
            return;

        }

        else if(v.CompareTo(root.data) > 0 )
         insert(v,ref root.right);

         else
         insert(v,ref root.left);
    }

    private bool search(T v, out Node parent, out Node x)
    {
        parent = x = null;
        if(root == null)
        return false;

        var q = root;
        while(q!=null)
        {
            if(v.CompareTo(q.data) == 0)
            {
                x = q;
                Console.WriteLine("Found "+ q.data);
                if( parent != null)
                Console.WriteLine("Parent"+ parent.data);
                else
                Console.WriteLine("Parent is null,because current element is Root of BST");//Remember
                // parent can be null.
                return true;
            }
            parent = q;
            if(v.CompareTo(q.data) > 0)
            q = q.right;
            else
            q = q.left;
        }
      return false;
    }

    public void pre()
    {
        Console.WriteLine("pre");
        pre(root);
        Console.WriteLine();
    }

    private void pre(Node root)
    {
        if(root!=null)
        {
            Console.Write(root.data+" ");
            pre(root.left);
            pre(root.right);
          }
        return;

    }

    public void post()
    {
        Console.WriteLine("post");
        post(root);
        Console.WriteLine();
    }

    private void post(Node root)
    {
        if(root!=null)
        {
            post(root.left);
            post(root.right);
            Console.Write(root.data+" ");
        }
        return;

    }

    public void inorder()
    {
        Console.WriteLine("in");
        inorder(root);
        Console.WriteLine();
    }

    private void inorder(Node root)
    {
        if(root!=null)
        {
            inorder(root.left);
            Console.Write(root.data+" ");
            inorder(root.right);

        }
        return;

    }
    public void delete(T v)
    {
        Node parent,x;
        var found = search(v,out parent, out x);

        if(!found)
        {
            Console.WriteLine("Element not present in BST.Cannot delete this element.");
            return;
        }
        // two children
        if(x.left != null && x.right != null)
        {
            // find leftmost xsucc
            var xsucc = x.right;
            parent = x;//Remember ,key step set BOTH xsucc and the parent.

            while(xsucc.left !=null)
            {
                parent = xsucc;
                xsucc = xsucc.left;
            }
        // set x = xsucc
        x.data = xsucc.data;
        x = xsucc;// handle as a single child deletion in case below
        }

        // no children
        if(x.left == null && x.right == null)
        {
            if(parent.left ==x)
            {
                parent.left = null;
            }
            else
            parent.right = null;

        }

// left child
        if(x.left!=null && x.right==null)
    {
        if(parent.left == x)
        {
            parent.left = x.left;
        }
        else
        parent.right = x.left;
    }

    // right child
        if(x.left==null && x.right!=null)
    {
        if(parent.left == x)
        {
            parent.left = x.right;
        }
        else
        parent.right = x.right;
    }
    }

}