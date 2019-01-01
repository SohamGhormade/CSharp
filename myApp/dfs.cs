using System;
using System.Collections.Generic;
namespace DataStructures
{
    //undirected graph
    public class Graph
    {
        private int vertices;// # of vertices
        private int edges;//# of edges

        private List<int>[] adj;// adjacency list representation
        public int V()
        {
            return vertices;

        }

        public int E()
        {
            return vertices;

        }
        public Graph(int V)
        {
            this.vertices = V;
            adj = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public void addEdge(int v1, int v2)
        {
            adj[v1].Add(v2);
            adj[v2].Add(v1);
            edges++;
        }
        // returns the list of adjacent vertices for a given
        // vertex v.
        public List<int> adjacent(int v)
        {
            return adj[v];
        }
    }
}


namespace DataStructures
{
    public class DFS
    {
        private bool[] marked;// has the element been visited
        private int[] edgeTo;
        private Graph graph;

        public DFS(Graph graph, int s)
        {
            this.graph = graph;
            int v = graph.V();
            marked = new bool[v];
        }
        private void dfs(int v)
        {
            marked[v] = true;
            for (int i = 0; i < graph.V(); i++)
            {
                if (!marked[i])
                    dfs(i);
            }

        }

    }
}

