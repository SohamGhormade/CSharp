using System;

//Implement HashTable in C#
// Use for efficient constant time lookups.
// 19 mins on whiteboard
// 11 mins code
// Works fine.

// TODO :implement ContainsKey and Clear functions.
public class KeyValuePair<K,V> where K : IComparable
{
    public K key;
    public V value;
    public KeyValuePair<K,V> next;
}

public class SequentialSearch<K,V> where K : IComparable
{
    private KeyValuePair<K,V> first;
    public V get(K key)
    {
        for(var x = first;x !=null;x=x.next)
        {
            if(x.key.CompareTo(key)==0)
            {
                return x.value;
            }
        }

        return default(V);
    }

    public void put(K key, V value)
    {
        for(var x = first;x !=null;x = x.next)
        {
            if(x.key.CompareTo(key)==0)
            {
                x.value = value;//update
            }
        }
        //if not present,then add
        var oldF = first;
        first = new KeyValuePair<K,V>();
        first.key = key;
        first.value = value;
        first.next = oldF;
    }
}

public class HashTable<K,V>  where K : IComparable
{
    private int m = 297;
    private SequentialSearch<K,V>[] ss;

    private int hash(K key)
    {
        return key.GetHashCode()%m;
    }

    public V get(K key)
    {
        return ss[hash(key)].get(key);
    }

  public HashTable()
  {
      ss = new SequentialSearch<K,V>[m];
  }
    public void put(K key, V value)
    {
        ss[hash(key)].put(key, value);
    }
}