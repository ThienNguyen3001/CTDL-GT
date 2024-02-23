using Amazon.Runtime;
using System;

namespace CTDL_GT
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree bst = new BinarySearchTree();
            //bst.Insert(new Node(1));
            //bst.Insert(new Node(0));
            //bst.Insert(new Node(2));
            //bst.Insert(new Node(5));
            //bst.Insert(new Node(4));
            //bst.Insert(new Node(7));
            //bst.Insert(new Node(3));
            //bst.Insert(new Node(6));
            //bst.Insert(new Node(10));
            //bst.Insert(new Node(9));
            //bst.Insert(new Node(8));
            //bst.PreOrder();
            //Console.WriteLine(bst.Search(5));

            Graph g = new Graph(5);
            //g.AddUnDirEdge(1,2);
            //g.AddUnDirEdge(1, 3);
            //g.AddUnDirEdge(1, 4);
            //g.AddUnDirEdge(2, 5);
            //g.AddUnDirEdge(2, 6);
            //g.AddUnDirEdge(4, 7);
            //g.AddUnDirEdge(4, 8);
            //g.AddUnDirEdge(5, 9);
            //g.AddUnDirEdge(5, 10);
            //g.AddUnDirEdge(7, 11);
            //g.AddUnDirEdge(7, 12);

            //g.AddDirEdge(7, 6);
            //g.AddDirEdge(7, 5);
            //g.AddDirEdge(5, 4);
            //g.AddDirEdge(6, 4);
            //g.AddDirEdge(6, 3);
            //g.AddDirEdge(5, 2);
            //g.AddDirEdge(3, 1);
            //g.AddDirEdge(2, 1);
            //g.AddDirEdge(1, 8);

            g.AddDirWeightEdge(1, 2, 6);
            g.AddDirWeightEdge(1, 3, 5);
            g.AddDirWeightEdge(3, 2, -2);
            g.AddDirWeightEdge(3, 4, 4);
            g.AddDirWeightEdge(3, 5, 3);
            g.AddDirWeightEdge(2, 4, -1);
            g.AddDirWeightEdge(4, 5, 3);
            g.BellmanFord(1);
        }
    }
}
