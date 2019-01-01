using System;

namespace DataStructures
{   // Works--verifed.
    // Binary search tree in C#.
    // T should implement IComparable.
    public class MyBST<T> where T : IComparable
    {
        private class Node
        {
            public Node L;
            public Node R;
            public T data;
        }

        private Node root;


        // wrapper function to keep Node private to class.
        public void inorder()
        {
            Console.WriteLine("In-order");
            inorder(root);
            Console.WriteLine();
        }
        private void inorder(Node r)
        {
            if (r != null)
            {
                inorder(r.L);
                Console.Write(r.data + " ");
                inorder(r.R);
            }
            else
                return;
        }

        public void post()
        {
            Console.WriteLine("post-order");
            post(root);
            Console.WriteLine();
        }
        private void post(Node r)
        {
            if (r != null)
            {
                post(r.L);
                post(r.R);
                Console.Write(r.data + " ");
            }
            else
                return;
        }

        // wrapper function to keep Node private to class.
        public void pre()
        {
            Console.WriteLine("pre-order");
            pre(root);
            Console.WriteLine();
        }
        private void pre(Node r)
        {
            if (r != null)
            {
                Console.Write(r.data + " ");
                pre(r.L);
                pre(r.R);
            }
            else
                return;// IMP :return once done
        }

        // wrapper function to keep Node private to class.
        public void insert(T val)
        {
            insert(val, ref root);
        }
        private void insert(T val, ref Node r)
        {
            if (r == null)
            {
                r = new Node();
                r.data = val;
                r.L = r.R = null;
                return;
            }


            if (val.CompareTo(r.data) > 0)
                insert(val, ref r.R);
            else
                insert(val, ref r.L);
        }

        private bool search(T v, out Node parent, out Node x, Node root)
        {
            parent = x = null;
            if (root == null)
                return false;

            var q = root;
            while (q != null)
            {
                if (q.data.CompareTo(v) == 0)
                {
                    x = q;
                    Console.WriteLine("Found "+x.data+ " with parent "+ parent.data);
                    return true;
                }
                parent = q;

                if (q.data.CompareTo(v) > 0)
                {
                    q = q.L;

                }
                else q = q.R;
            }
            return false;

        }

        public void delete(T v)
        {
            delete(v, ref root);

        }
        private void delete(T v, ref Node r)
        {
            var s = search(v, out Node parent, out Node x, root);
            if (!s)
            {
                Console.WriteLine("Node does not exist in the tree.");
                return;
            }

            //two children -> reduce to one child case
            if (x.L != null && x.R != null)
            {
                var xsucc = x.R;
                while (xsucc.L != null)
                {
                    parent = xsucc;
                    xsucc = xsucc.L;
                }

                x = xsucc;
                x.data = xsucc.data;
            }

            // no children
            if (x.L == null && x.R == null)
            {
                if (parent.L == x)
                    parent.L = null;
                else
                    parent.R = null;
            }
            // right child
            if (x.L == null && x.R != null)
            {
                if (parent.L == x)
                    parent.L = x.R;
                else
                    parent.R = x.R;
            }
            // left child
            if (x.L != null && x.R == null)
            {
                if (parent.L == x)
                    parent.L = x.L;

                else
                    parent.R = x.L;
            }
        }
    }
}