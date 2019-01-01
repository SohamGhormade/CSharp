using System;
using System.Linq;
using BST;
using GoogleCandidateCoaching;
using DataStructures;
using System.Diagnostics;
using Algorithms;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSortTest();
            //MergeSortTest2();
            //TrieTest();
            //BSTTest();
            //HashtableTest();
            //QueueTest();
            //LinkedListTest();
            //StackTest();
            //ResizingStackTest();
            //NewMethod();

        }
        static void QuickSortTest()
        {
            var quickSort = new Quick();
            int[] a = { 4, 1, 7, 3, 8, 9, 11, 2 };
            quickSort.sort(a , 0, a.Length-1);
            int[] result = { 1, 2, 3, 4, 7, 8, 9, 11 };
            Debug.Assert(Enumerable.SequenceEqual(a,result));
        }
                static void MergeSortTest2()
        {
            var mergeSort = new MergeSort();
            int[] a = { 4, 1, 7, 3, 8, 9, 11, 2 };
            mergeSort.sort(a);
            int[] result = { 1, 2, 3, 4, 7, 8, 9, 11 };
            Debug.Assert(Enumerable.SequenceEqual(a,result));
        }
        static void MergeSortTest()
        {
            var mergeSort = new Sorting();
            int[] a = { 4, 1, 7, 3, 8, 9, 11, 2 };
            mergeSort.mergesort(a);
            int[] result = { 1, 2, 3, 4, 7, 8, 9, 11 };
            Debug.Assert(Enumerable.SequenceEqual(a,result));
        }
        static void TrieTest()
        {
            var trie = new MyTrie<int>();
            trie.put("sea", 3);
            trie.put("shells", 13);
            trie.put("she", 2);
            trie.put("the", 4);
            trie.put("shore", 5);

            Debug.Assert(trie.get("sea") == 3);
            Debug.Assert(trie.get("shells") == 13);
            Debug.Assert(trie.get("she") == 2);
            Debug.Assert(trie.get("the") == 4);
            Debug.Assert(trie.get("shore") == 5);
            trie.put("shore", 15);
            Debug.Assert(trie.get("shore") == 15);
        }
        //works fine.
        static void HeapTest()
        {

            var heap = new Heap<int>();
            Debug.Assert(heap.isEmpty());
            heap.insert(18);
            Debug.Assert(!heap.isEmpty());

            heap.insert(21);
            heap.insert(5);
            heap.insert(10);
            heap.insert(1);
            heap.insert(2);
            heap.insert(36);
            heap.insert(8);
            heap.insert(15);
            heap.insert(17);
            Debug.Assert(heap.size() == 10);
            var max = heap.deleteMax();

            Debug.Assert(max == 36);
            Debug.Assert(heap.size() == 9);

            max = heap.deleteMax();

            Debug.Assert(max == 21);
            Debug.Assert(heap.size() == 8);

            max = heap.deleteMax();

            Debug.Assert(max == 18);
            Debug.Assert(heap.size() == 7);
        }
        static void BSTTest()
        {
            var bst = new MyBST<int>();
            bst.insert(10);
            bst.insert(5);
            bst.insert(2);
            bst.insert(6);
            bst.insert(16);
            bst.insert(15);
            bst.insert(14);
            bst.inorder();
            bst.post();
            bst.pre();
            Console.WriteLine("Delete 15");
            bst.delete(15);
            bst.inorder();// should not contain 15!
            Console.WriteLine("Delete 2");
            bst.delete(2);
            bst.inorder();// should not contain 2!
        }

        static void HashtableTest()
        {
            var hashtable = new Hashtable<string, int>();
            hashtable.put("hi", 1);
            Debug.Assert(hashtable.get("hi").Equals(1));
            hashtable.put("hello", 8);
            Debug.Assert(hashtable.get("hello").Equals(8));
            hashtable.put("abc", 16);
            Debug.Assert(hashtable.get("abc").Equals(16));
            hashtable.put("hi", 33);//update
            Debug.Assert(hashtable.get("hi").Equals(33));
            Debug.Assert(hashtable.get("pqr").Equals(default(int)));// corner case

        }
        static void QueueTest()
        {
            var q = new Queue<int>();
            Debug.Assert(q.isEmpty());
            q.enqueue(1);
            Debug.Assert(q.size() == 1);

            q.enqueue(2);
            Debug.Assert(q.size() == 2);

            q.enqueue(3);
            Debug.Assert(q.size() == 3);

            Debug.Assert(1 == q.dequeue());
            Debug.Assert(2 == q.dequeue());
            Debug.Assert(3 == q.dequeue());

        }
        static void StackTest()
        {
            var stack = new Stack<int>();
            Debug.Assert(stack.isEmpty());

            stack.push(8);
            Debug.Assert(!stack.isEmpty());
            Debug.Assert(1 == stack.size());

            stack.push(3);
            Debug.Assert(2 == stack.size());

            stack.push(-67);
            Debug.Assert(3 == stack.size());

            Debug.Assert(-67 == stack.pop());
            Debug.Assert(2 == stack.size());

            Debug.Assert(3 == stack.pop());
            Debug.Assert(1 == stack.size());

            Debug.Assert(8 == stack.pop());
            Debug.Assert(0 == stack.size());
            Debug.Assert(stack.isEmpty());
            try
            {
                stack.pop();
            }

            catch (System.Exception e)
            {

                Console.WriteLine("exception thrown:" + e.Message);
            }
        }
        static void ResizingStackTest()
        {
            var stack = new ResizingStack<int>();
            Debug.Assert(stack.isEmpty());

            stack.push(8);
            Debug.Assert(!stack.isEmpty());
            Debug.Assert(1 == stack.size());

            stack.push(3);
            Debug.Assert(2 == stack.size());

            stack.push(-67);
            Debug.Assert(3 == stack.size());


            Debug.Assert(-67 == stack.pop());
            Debug.Assert(2 == stack.size());

            Debug.Assert(3 == stack.pop());
            Debug.Assert(1 == stack.size());

            Debug.Assert(8 == stack.pop());
            Debug.Assert(0 == stack.size());
            Debug.Assert(stack.isEmpty());
            try
            {
                stack.pop();
            }

            catch (System.Exception e)
            {

                Console.WriteLine("exception thrown:" + e.Message);
            }
        }
        private static void NewMethod()
        {
            Problem p1 = new Problem();
            int[] arr = { 2, -1, 1, 2, 2 };
            Console.WriteLine(p1.hasCompleteCycle(arr));//true
            int[] arr2 = { -1, 2 };
            Console.WriteLine(p1.hasCompleteCycle(arr2));//false
            Console.WriteLine("Hello World!");
            var p = new Problem4_5();
            var n = new Node(5);

            var n1 = new Node(2);
            var n2 = new Node(1);

            var n3 = new Node(3);


            var n4 = new Node(15);
            var n5 = new Node(18);
            n.l = n1;
            n.r = n5;
            n5.l = n4;
            n1.l = n2;
            n1.r = n3;

            var a = p.bstSequence(n, 12);
            foreach (int i in a)
                Console.Write(i + " ");

            Console.WriteLine();
            var root = new Node<int>();
            root.data = 0;
            root.left = null;
            root.right = null;
            var bst = new BST<int>(root);
            bst.insert(4);
            bst.insert(23);
            bst.insert(3);
            bst.inorder();
            Console.WriteLine();
            bst.delete(3);
            bst.inorder();
            // Console.WriteLine();
            // bst.delete(1);
            // bst.inorder();
            // Console.WriteLine();
            // bst.delete(100);

            var heap = new Heap(20);
            heap.insert(7);
            heap.insert(29);
            heap.insert(32);
            heap.insert(20);
            heap.insert(28);
            heap.insert(22);
            heap.insert(17);
            heap.insert(16);
            heap.insert(14);
            heap.insert(15);
            Console.WriteLine();
            Console.WriteLine("Is Heap empty?" + heap.isEmpty());
            Console.WriteLine("size: " + heap.size());
            Console.WriteLine("Max element deleted:" + heap.delMax());
            Console.WriteLine("size" + heap.size());

            var trie = new Trie<int>();
            trie.put("by", 4);
            trie.put("sea", 2);
            trie.put("she", 0);
            trie.put("sells", 1);
            trie.put("shells", 3);
            trie.put("the", 5);
            Console.WriteLine("by " + trie.get("by"));
            Console.WriteLine("sells " + trie.get("sells"));
        }

        public static void LinkedListTest()
        {
            var l = new MyLinkedList();
            Debug.Assert(l.isEmpty());

            l.insertAtBeg(1);
            Debug.Assert(!l.isEmpty());
            Debug.Assert(l.size() == 1);

            l.insertAtEnd(5);
            Debug.Assert(l.size() == 2);

            l.insertAtEnd(6);
            l.insertAtEnd(2);
            l.insertAtBeg(3);
            Debug.Assert(l.size() == 5);

            Debug.Assert(3 == l.removeAtBeg());
            Debug.Assert(1 == l.removeAtBeg());
            Debug.Assert(l.size() == 3);

            l.insertAtBeg(13);
            Debug.Assert(l.size() == 4);

            Debug.Assert(2 == l.removeAtEnd());
            Debug.Assert(6 == l.removeAtEnd());
            Debug.Assert(l.size() == 2);

            l.insertAtEnd(131);
            Debug.Assert(l.size() == 3);

        }
    }


    public class Node<T> where T : IComparable
    {
        public T data;
        public Node<T> left, right;
    }

    #region BST implementation
    // implement a BST,Heap and a Trie
    public class BST<T> where T : IComparable
    {

        private Node<T> root;

        public BST(Node<T> r)
        {
            root = r;
        }

        public void inorder()
        {
            inorder(root);
        }
        public void inorder(Node<T> r)
        {
            if (r != null)
            {
                inorder(r.left);
                Console.Write(r.data + " ");
                inorder(r.right);
            }
            else
                return;
        }
        public void insert(T val)
        {
            insert(val, ref root);
        }
        private void insert(T val, ref Node<T> n)
        {
            if (n == null)
            {
                n = new Node<T>();
                n.data = val;
                n.left = null;
                n.right = null;
            }
            else
            {
                if (val.CompareTo(n.data) > 0)
                {
                    insert(val, ref n.right);

                }
                else
                {
                    insert(val, ref n.left);
                }
            }
            return;
        }

        //search for a given element in the BST
        // return true if the element exists
        // return false otherwise
        // also return the parent and the node
        private bool search(T val, out Node<T> parent, out Node<T> x)
        {
            bool isFound = false;
            Node<T> q = root;
            parent = null;
            x = null;
            while (q != null)
            {
                if (q.data.CompareTo(val) == 0)
                {
                    x = q;
                    Console.WriteLine("element found:" + x.data);
                    isFound = true;
                    break;
                }
                parent = q;

                if (q.data.CompareTo(val) > 0)
                    q = q.left;
                else
                    q = q.right;

            }

            return isFound;

        }

        public void delete(T val)
        {
            bool isFound = search(val, out Node<T> parent, out Node<T> x);
            Console.WriteLine("isFound " + isFound + " ");
            if (!isFound)
                return;

            //two children
            if (x.left != null && x.right != null)
            {
                Node<T> xsucc = x.right;
                while (xsucc.left != null)
                {
                    parent = xsucc;
                    xsucc = xsucc.left;
                }

                x.data = xsucc.data;
                x = xsucc;
            }

            // no children
            if (x.left == null && x.right == null)
            {
                if (parent.left == x)
                    parent.left = null;
                else
                    parent.right = null;


            }
            // left child
            if (x.left != null && x.right == null)
            {
                if (parent.left != null)
                    parent.left = x.left;
                else
                    parent.right = x.right;


            }
            // right child
            if (x.left == null && x.right != null)
            {
                if (parent.left != null)
                    parent.left = x.right;
                else
                    parent.right = x.right;
            }
        }

    }
    #endregion

    //Implement a heap in C#
    #region Heap
    public class Heap
    {
        private int[] a;
        private int n = 0;
        public Heap(int size)
        {
            a = new int[size + 1];
        }
        public bool isEmpty()
        {
            return n == 0;
        }
        public int size()
        {
            return n;
        }
        public void insert(int i)
        {
            a[++n] = i;
            swim(n);
        }
        public int delMax()
        {
            int max = a[1];

            swap(1, n--);
            a[n + 1] = 0;
            sink(1);

            return max;
        }
        //re-heapify towards root node
        private void swim(int k)
        {
            while (k > 1 && a[k] > a[k / 2])
            {
                swap(k, k / 2);
                k = k / 2;
            }
        }

        private void swap(int x, int y)
        {
            int temp = a[x];
            a[x] = a[y];
            a[y] = temp;

        }
        //re-heapify toward leaf nodes
        private void sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && (a[j] < a[j + 1])) j++;
                if (!(a[k] < a[j])) break;
                swap(k, j);
                k = j;
            }
        }
    }


    #endregion
    public class TrieNode<T>
    {
        //private int R = 256;// radix
        public T val;
        public TrieNode<T>[] next = new TrieNode<T>[256];
    }

    #region Trie
    public class Trie<T>
    {
        private TrieNode<T> root = new TrieNode<T>();

        public T get(string key)
        {
            TrieNode<T> x = get(root, key, 0);
            if (x == null) return default(T);
            return x.val;
        }

        private TrieNode<T> get(TrieNode<T> x, string key, int d)
        {
            if (x == null) return null;
            if (d == key.Length) return x;
            char c = key[d];
            return get(x.next[c], key, d + 1);
        }

        public void put(string key, T val)
        {
            root = put(root, key, val, 0);
        }

        private TrieNode<T> put(TrieNode<T> x, string key, T val, int d)
        {
            if (x == null) x = new TrieNode<T>();
            if (d == key.Length)
            {
                x.val = val;
                return x;
            }

            char c = key[d];
            x.next[c] = put(x.next[c], key, val, d + 1);
            return x;
        }

    }
    #endregion Trie

}




