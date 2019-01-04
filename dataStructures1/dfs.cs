using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        foreach (var w in G.Adj(v))
        {
            if (!marked[w])
            {
                dfs(G, w);
                edgeTo[w] = v;
            }
        }

    }

    public Stack<int> pathTo(int v)
    {
        if (!hasPath(v))
        {
            return null;
        }

        var path = new Stack<int>();
        for (var x = v; x != s; x = edgeTo[x])
        {
            path.push(x);
            Console.Write(x + " ");
        }
        path.push(s);
        Console.Write(s + " ");
        return path;
    }
}
public static class DFS_Test

{
    public static void test()
    {
        var graph = new Graph(6);
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 4);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(4, 3);
        graph.AddEdge(0, 5);
        graph.AddEdge(0, 4);
        var dfs = new DepthFirstPath(graph, 0);
        var s = new Stack<int>();
        s.push(1);
        s.push(3);
        Console.WriteLine("Print paths:");
        dfs.pathTo(3);
        dfs.pathTo(4);
        Debug.Assert(dfs.hasPath(4).Equals(true));
        Debug.Assert(dfs.hasPath(3).Equals(true));
        Debug.Assert(dfs.hasPath(5).Equals(true));
        Debug.Assert(dfs.hasPath(2).Equals(true));
    }
}