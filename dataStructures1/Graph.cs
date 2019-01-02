
// Undirected Graph implementation in C#.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Graph
{
    private int _v;// # of vertices
    private int  _e;// # of edges
    private List<int>[] _adj;// adjacent vertices for a given vertex

    public Graph(int v)
    {
        this._v = v;
        _adj = new List<int>[v];
        // intialize adjacency List
        for(int i = 0 ; i < v;i++)
        {
            _adj[i] = new List<int>();
        }
    }

// read from stream
   public Graph(System.IO.StreamReader streamReader)
   :this(streamReader.Read())
   {
       _e = streamReader.Read();
       for(int i =0 ;i < _e;i++)
       {
           var v = streamReader.Read();
           var w = streamReader.Read();
           AddEdge(v,w);
       }

   }
    public int V()
    {
      return _v;
    }

    public int E()
    {
      return _e;
    }

     public IEnumerable<int> Adj(int v)
     {
          return _adj[v];
     }

    public void AddEdge(int v, int w)
    {
         _e++;
        // undirected v-> w and w -> v are both counted.
        _adj[v].Add(w);
        _adj[w].Add(v);
    }
}
public class GraphTest
{
    public void test()
    {
      var graph = new Graph(6);
      graph.AddEdge(0,1);
      graph.AddEdge(1,2);
      graph.AddEdge(1,4);
      graph.AddEdge(1,3);
      graph.AddEdge(2,3);
      graph.AddEdge(4,3);
      graph.AddEdge(0,5);
      graph.AddEdge(0,4);

      int[] arr = {0,2,4,3};
      Debug.Assert(graph.E()==8, "the number of edges does not match the expected value.");
      Debug.Assert(graph.V()==6, "the number of vertices does not match the expected value.");
      Debug.Assert(Enumerable.SequenceEqual(graph.Adj(1),arr.ToList()));
      int[] arr1 = {1,2,4};
      Debug.Assert(Enumerable.SequenceEqual(graph.Adj(3),arr1.ToList()));

    }
    }