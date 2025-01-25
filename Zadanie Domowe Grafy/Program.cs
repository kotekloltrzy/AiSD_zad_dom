using System;
using System.Collections.Generic;

class Graph
{
    public int nodes;
    public List<int>[] adjList;

    public Graph(int vertices)
    {
        this.nodes = vertices;
        adjList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adjList[v].Add(w);
    }

    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < nodes; i++)
        {
            result += i + ": " + string.Join(", ", adjList[i]) + "\n";
        }
        return result;
    }
}
class BFS
{
    public static void Search(Graph graph, int startVertex)
    {
        bool[] visited = new bool[graph.nodes];
        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            int vertex = queue.Dequeue();
            Console.Write(vertex + " ");

            foreach (int neighbour in graph.adjList[vertex])
            {
                if (!visited[neighbour])
                {
                    visited[neighbour] = true;
                    queue.Enqueue(neighbour);
                }
            }
        }
    }
}
class DFS
{
    public static void Search(Graph graph, int startVertex)
    {
        bool[] visited = new bool[graph.nodes];
        DFSUtil(graph, startVertex, visited);
    }

    private static void DFSUtil(Graph graph, int vertex, bool[] visited)
    {
        visited[vertex] = true;
        Console.Write(vertex + " ");

        foreach (int neighbour in graph.adjList[vertex])
        {
            if (!visited[neighbour])
            {
                DFSUtil(graph, neighbour, visited);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Graph g = new Graph(4);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine(g);

        Console.WriteLine("\nBFS starting from vertex 2:");
        BFS.Search(g, 2);

        Console.WriteLine("\nDFS starting from vertex 2:");
        DFS.Search(g, 2);
        Console.WriteLine("\n");
    }
}