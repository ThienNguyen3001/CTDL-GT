using System;

namespace CTDL_GT
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, e;
            n = int.Parse(Console.ReadLine());
            e = int.Parse(Console.ReadLine());
            Graph g = new Graph(n,e);
            for (int i = 0; i < g.edges; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                int u = int.Parse(numbers[0]);
                int v = int.Parse(numbers[1]);
                g.AddDirEdge(u, v);
            }

            g.PrintTopo();

        }
    }
}
