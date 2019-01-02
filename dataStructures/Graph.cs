
// Undirected Graph implementation in C#.
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
   public Graph(StreamReader streamReader)
   {
       this(streamReader.ReadInt());
       _e = streamReader.ReadInt();
       for(int i =0 ;i < _e;i++)
       {
           var v = streamReader.ReadInt();
           var w = streamReader.ReadInt();
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

    public AddEdge(int v1, int v2)
    {
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

      Debug.Assert(SequenceEquals(graph.Adj(), ));
      Debug.Assert(SequenceEquals(graph.Adj(), ));
    }
}