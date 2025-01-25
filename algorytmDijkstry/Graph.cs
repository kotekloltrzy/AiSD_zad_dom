using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algorytmDijkstry
{
    internal class Graph
    {
        private int V;
        private List<Tuple<int, int>>[] adj;

        public Graph(int V)
        {
            this.V = V;
            adj = new List<Tuple<int, int>>[V];
            for (int i = 0; i < V; ++i)
                adj[i] = new List<Tuple<int, int>>();
        }

        public void AddEdge(int u, int v, int weight)
        {
            adj[u].Add(new Tuple<int, int>(v, weight));
            adj[v].Add(new Tuple<int, int>(u, weight));
        }

        public void Dijkstra(int src)
        {
            int[] dist = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, sptSet);
                sptSet[u] = true;

                foreach (var item in adj[u])
                {
                    int v = item.Item1;
                    int weight = item.Item2;

                    if (!sptSet[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        dist[v] = dist[u] + weight;
                }
            }

            PrintSolution(dist);
        }

        private int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;

        }

        private void PrintSolution(int[] dist)
        {
            String wynik = "";
            wynik += ("Vertex \t Distance from Source\n");
            for(int i = 0; i < V; i++)
                wynik+=(i+"\t\t " + dist[i]+"\n");
            MessageBox.Show(wynik);
        }
    }
}
