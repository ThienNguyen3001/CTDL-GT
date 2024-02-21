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
            g.AddDirEdge(1, 2);
            g.AddDirEdge(1, 3);
            g.AddDirEdge(1, 4);
            g.AddDirEdge(2, 3);
            g.AddDirEdge(2, 5);
            g.AddDirEdge(3, 5);
            g.DFS(1);
        }
    }
}
