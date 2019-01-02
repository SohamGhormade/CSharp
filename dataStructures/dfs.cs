using System;
using System.Collection.Generics;

public class DepthFirstPath
{
    private bool[] marked;
    private List<int> edgeTo;

    public DepthFirstPath(Graph G, int s)
    {
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

    private void dfs(Graph G, int s)
    {
        marked[s] = true;
        foreach(var v in G.adj(s) )
        {
            if(!marked[v])
             {
                 dfs(G, v);
                 edgeTo.Add(v);
             }
        }

    }
}