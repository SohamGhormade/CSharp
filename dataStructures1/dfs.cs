using System;
using System.Collections.Generic;

public class DepthFirstPath
{
    private bool[] marked;
    private int[] edgeTo;
    private int s;// source vertex

    public DepthFirstPath(Graph G, int s)
    {
        this.s = s;
        var vertices = G.V();
        marked = new bool[vertices];
        edgeTo = new int[vertices];
        dfs(G, s);
    }

    // returns true if source s has a path to to vertex v.
    // returns false otherwise.
    public bool hasPath(int v)
    {
        return marked[v];
    }

    private void dfs(Graph G, int v)
    {
        marked[v] = true;
        foreach(var w in G.Adj(v) )
        {
            if(!marked[w])
             {
                 dfs(G, w);
                 edgeTo[w]= v;
             }
        }

    }

 public IList<int> pathTo(int v)
 {
     var path = new Stack<int>();
     for(var x = v; x!=s; x = edgeTo[v] )
     {
         path.push(x);
     }
     path.push(s);
     return path;
 }
}