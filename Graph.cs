using System;
using System.Collections.Generic;

namespace CTDL_GT
{
    public class Graph
    {
        private int[] distance = new int[1000];
        private List<int>[] adjacencyList;
        private List <Tuple<int,int, int>> adj = new List<Tuple<int, int, int>>();
        private int vertices;
        private bool[] visited;
        private Stack<int> topo = new Stack<int>();
        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjacencyList = new List<int>[vertices + 1];
            for (int i = 1; i <= vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            //Khởi tạo tất cả các phần tử trong visited = false
            visited = new bool[vertices + 1];
        }
        /// <summary>
        /// Dùng cho đồ thị vô hướng
        /// </summary>
        public void AddUnDirEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }
        /// <summary>
        /// Dùng cho đồ thị có hướng nhưng ko có trọng số
        /// </summary>
        public void AddDirEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
        }
        /// <summary>
        /// Dùng cho đồ thị có hướng và có trọng số
        /// </summary>
        public void AddDirWeightEdge(int u, int v, int w)
        {
            adj.Add(Tuple.Create(u, v, w));
        }
        /// <summary>
        /// In đồ thị (Không có trọng số)
        /// </summary>
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
        /// <summary>
        /// In ra thuật toán tìm kiếm theo chiều sâu DFS
        /// </summary>
        public void DFS(int u)
        {
            visited[u] = true;
            Console.Write(u + " "); 
            foreach (var i in adjacencyList[u])
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }
        }
        /// <summary>
        /// DFS cho Topo
        /// </summary>
        private void DFS_Topo(int u)
        {
            visited[u] = true;
            foreach (var i in adjacencyList[u])
            {
                if (!visited[i])
                {
                    DFS_Topo(i);
                }
            }
            topo.Push(u);
        }
        /// <summary>
        /// In ra thuật toán tìm kiếm theo chiều rộng BFS
        /// </summary>
        public void BFS(int u)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(u);
            visited[u] = true;
            while (q.Count != 0)
            {
                int x = q.Dequeue();
                Console.Write(x + " ");
                foreach (var i in adjacencyList[x])
                {
                    if (!visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
        /// <summary>
        /// In ra thứ tự sắp xếp Topo
        /// </summary>
        public void PrintTopo()
        {
            for (int i = 1; i <= vertices; i++)
            {
                if (!visited[i])
                {
                    DFS_Topo(i);
                }
            }
            foreach (int x in topo)
            {
                Console.Write(x + " ");
            }
        }
        /// <summary>
        /// In ra thuật toán tìm đường đi ngắn nhất (Bellman Ford)
        /// </summary>
        public void BellmanFord(int x)
        {
            for (int i = 1; i <= vertices; i++)
            {
                distance[i] = 999999;
            }
            distance[x] = 0;
            for (int i = 1; i <= vertices - 1; i++)
            {
                foreach (var e in adj)
                {
                    int a, b, w;
                    a = e.Item1;
                    b = e.Item2;
                    w = e.Item3;
                    distance[b] = Math.Min(distance[b], distance[a] + w);
                }
            }
            // In kết quả
            for (int i = 1; i <= vertices; i++)
            {
                if (distance[i] == 999999)
                {
                    Console.WriteLine($"No path from {x} to {i}");
                }
                else
                {
                    Console.Write($"Shortest path from {x} to {i}: ");
                    List<int> path = new List<int>();
                    int current = i;
                    while (current != x)
                    {
                        path.Add(current);
                        foreach (var e in adj)
                        {
                            int a = e.Item1;
                            int b = e.Item2;
                            int w = e.Item3;
                            if (distance[current] == distance[a] + w && current == b)
                            {
                                current = a;
                                break;
                            }
                        }
                    }
                    path.Add(x);
                    path.Reverse();
                    Console.WriteLine(string.Join(" ", path) + $" Cost: {distance[i]}");
                }
            }
        }
    }
}  