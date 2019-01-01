namespace DataStructures
{
    //Implement hashtable in C#.
    //TODO 30 + mins :there is scope for improvement
    // O(1) for lookup,insert and delete.
    //use for quick look ups.
    public class Hashtable<K, V>
    {
        private int m;//size of hash table
        private SequentialSearch<K, V>[] ss;
        public Hashtable(int m)
        {
            this.m = m;
            ss = new SequentialSearch<K, V>[m];
            for (int i = 0; i < m; i++)
                ss[i] = new SequentialSearch<K, V>();
        }

        public Hashtable() : this(297)
        { }

        //TODO Note the hash function
        private int hash(K key)
        {
            return (key.GetHashCode() & 0x7ffffff) % m;
        }
        public void put(K key, V value)
        {
            ss[hash(key)].put(key, value);
        }

        public V get(K key)
        {
            return ss[hash(key)].get(key);
        }

    }

    //use separate chaining for conflict resolution
    public class SequentialSearch<K, V>
    {
        private class Node
        {
            public K key;
            public V val;
            public Node next;
        }

        private Node first;

        public void put(K key, V value)
        {
            for (var x = first; x != null; x = x.next)
            {
                if (x.key.Equals(key))
                {
                    x.val = value;
                    return;
                }
            }
            var oldF = first;
            first = new Node();
            first.key = key;
            first.val = value;
            first.next = oldF;
        }

        public V get(K key)
        {
            for (var x = first; x != null; x = x.next)
            {
                if (x.key.Equals(key))
                {
                    return x.val;
                }
            }
            return default(V);
        }

    }
}