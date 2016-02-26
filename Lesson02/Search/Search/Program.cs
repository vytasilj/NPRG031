using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson02.Tree;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = InitializeTree(10);

            Node<int> bfs = FindUsingBFS(root, 5);
            Node<int> dfs = FindUsingDFS(root, 5);
        }


        private static Node<int> InitializeTree(int maxValue)
        {
            Node<int> root = new Node<int>(0);
            for (int i = 1; i <= maxValue; i++)
            {
                root.Add(i);
            }
            return root;
        }

        private static Node<int> FindUsingBFS(Node<int> root, int value)
        {
            return null;
        }

        private static Node<int> FindUsingDFS(Node<int> root, int value)
        {
            return null;
        }
    }
}
