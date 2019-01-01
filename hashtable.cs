using System;
//Algorithms ,Sedgewick
//Client code
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var ht = new SeparateChainingHashST<char,int>();
	    ht.put('a',12);
		ht.put('f',1);
		ht.put('d',132);

		Console.WriteLine("Get a "+ht.getV('a'));//12
		ht.put('a',4);//update the value
		Console.WriteLine("Get a "+ht.getV('a'));//4
		Console.WriteLine("Get c "+ht.getV('c'));//null

		Console.WriteLine("Get f "+ht.getV('f'));//1
		Console.WriteLine("Get h "+ht.getV('d'));//132
	}
}

//Class to do a linear search per linked list
public class SequentialSearchST<Key,Value>
{
 private Node<Key,Value> first;
 private class Node<Key,Value>
 {
   public Node<Key,Value> next;
   public Key key;
   public Value val;

   public Node(Key k,Value v,Node<Key,Value>  n)
   {
     this.key = k;
     this.val=v;
     this.next= n;
   }
  }

  //Retuns the value for a given key
  public Value getV(Key k)
  {
  for(Node<Key,Value> n = first;n!=null;n=n.next)
  {
  if(n.key.Equals(k))
  {
  return n.val;//search hit

  }

  }
  return default(Value);//search miss
  }

  //Puts the specified Key and Value into the HT
  public void put(Key k,Value v)
  {
    for(Node<Key,Value> n = first;n!=null;n=n.next)
  {
  if(n.key.Equals(k))
  {
  n.val = v;//search hit:update value
  return;

  }

  }

  first = new Node<Key,Value>( k,v,null);

  }

}


public class SeparateChainingHashST<Key,Value>
{
private int m;//size of the HT
private SequentialSearchST<Key,Value> []st;//separate chains
public SeparateChainingHashST():this(997)
{
}

 public SeparateChainingHashST(int m)
{
   this.m = m;
   st = new SequentialSearchST<Key,Value>[m];
   for(int i = 0;i<m;i++)
   st[i] = new SequentialSearchST<Key,Value>();
}

//hashing function
private int hash(Key k)
{
return (k.GetHashCode()& 0xfffffff)%m;
}

public void put(Key k,Value v)
{
 st[hash(k)].put(k,v);
}

public Value getV(Key k)
{
return st[hash(k)].getV(k);
}
}