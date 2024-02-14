using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace CTDL_GT
{
    public class Graph
    {
        private List<int>[] adjacencyList;
        private List<Tuple<int, int>>[] adj;
        public int vertices;
        public int edges;
        private bool[] visited;
        private Stack<int> topo = new Stack<int>();
        public Graph(int vertices, int edges)
        {
            this.vertices = vertices;
            this.edges = edges;
            adjacencyList = new List<int>[vertices + 1];
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            //Khởi tạo tất cả các phần tử trong visited = false
            visited = new bool[vertices + 1];
        }
        public void AddUnDirEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }
        public void AddDirEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
        }
        public void AddDirWeightEdge(int u,int v,int w)
        {
            adj[u].Add(Tuple.Create(v,w));
        }
        public void PrintGraph()
        {
            for (int i = 1; i <= vertices; i++)
            {
                Console.Write(i + ": ");
                foreach (var neighbor in adjacencyList[i])
                {
                    Console.Write(neighbor + " ");
                }
                Console.WriteLine();
            }
        }
        public void DFS(int u)
        {
            //Console.Write(u + " "); Dùng nếu dùng bfs thông thường
            visited[u] = true;
            foreach (var i in adjacencyList[u])
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }
            topo.Push(u);//dùng khi cần topo
        }
        public void BFS(int u)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(u);
            visited[u] = true;
            while (q.Count != 0)
            {
                int x = q.Dequeue();
                Console.Write(x + " ");
                foreach(var i in adjacencyList[x])
                {
                    if (!visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
        public void PrintTopo()
        {
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }
            foreach(int x in topo)
            {
                Console.Write(x+" ");
            }
        }
    }
}