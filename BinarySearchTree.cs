using System;

namespace CTDL_GT
{
    public class BinarySearchTree
    {
        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(Node node)
        {
            root = InsertHelper(root, node);
        }
        Node InsertHelper(Node root, Node node)
        {
            int data = node.value;
            if (root == null)
            {
                root = node;
                return root;
            }
            else if (root.value > node.value)
            {
                root.left = InsertHelper(root.left, node);
            }
            else
            {
                root.right = InsertHelper(root.right, node);
            }
            return root;
        }
        public void PreOrder()
        {
            PreOrderHelper(root);
        }
        void PreOrderHelper(Node root)
        {
            if (root != null)
            {
                Console.Write(root.value + " ");
                PreOrderHelper(root.left);
                PreOrderHelper(root.right);
            }
        }
        public void InOrder()
        {
            InOrderHelper(root);
        }

        private void InOrderHelper(Node root)
        {
            if (root != null)
            {
                InOrderHelper(root.left);
                Console.Write(root.value+" ");
                InOrderHelper(root.right);
            }
        }
        public void PostOrder()
        {
            PostOrderHelper(root);
        }

        private void PostOrderHelper(Node root)
        {
            if (root != null)
            {
                PostOrderHelper(root.left);
                PostOrderHelper(root.right);
                Console.Write(root.value + " ");
            }
        }

        public bool Search(int value)
        {
            return SearchHelper(root, value);
        }

        private bool SearchHelper(Node root, int value)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.value == value)
            {
                return true;
            }
            else if (root.value > value)
            {
                return SearchHelper(root.left, value);
            }
            else
            {
                return SearchHelper(root.right, value);
            }
        }
    }
}