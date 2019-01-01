using System;

namespace DataStructures
{
    //Implement Trie in C#.
    public class MyTrie<T>
    {
        private const int R = 256;//radix
        private class Node
        {
            public T val;
            public Node[] next = new Node[R];//R-way trie
        }
        private Node root;
        public T get(string key)
        {
            if (key == null)
                return default(T);

            var n = get(key, root, 0);
            if (n != null) return n.val;
            return default(T);
        }
        private Node get(string key, Node x, int d)
        {
            if (x == null)
            {
                return null;

            }
            if (key.Length == d) return x;

            var c = key[d];
            return get(key, x.next[c], d + 1);
        }

        public void put(string key, T val)
        {
            if (key == null) return;
           root = put(key, val, root, 0);//imp

        }
        private Node put(string key, T val, Node x, int d)
        {
            if (x == null)
            {
                x = new Node();

            }
            if (key.Length == d)
            {
                x.val = val; //update
                return x;

            }
            var c = key[d];
            x.next[c] = put(key, val, x.next[c], d + 1);//why?
            return x;


        }
    }
}