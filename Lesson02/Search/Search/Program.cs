using System.Collections.Generic;
using Search.Tree;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = InitializeTree(10);

            Node<int> bfs = FindUsingBFS(root, 5);
            Node<int> dfs = FindUsingDFS(root, 5);
            Node<int> dfs2 = FindUsingDFS2(root, 5);
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
            // inicializace fronty
            Queue<Node<int>> fifo = new Queue<Node<int>>();
            // Přidání prvku do fronty
            fifo.Enqueue(root);

            while (true)
            {
                // vybrání prvku z fronty
                Node<int> actual = fifo.Dequeue();

                if (actual.Value == value)
                    return actual;

                if (actual.Left != null)
                    fifo.Enqueue(actual.Left);
                if (actual.Right != null)
                    fifo.Enqueue(actual.Right);
            }
        }

        /// <summary>
        /// DFS pomocí rekurze
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Node<int> FindUsingDFS(Node<int> root, int value)
        {
            if (root.Value == value)
                return root;

            Node<int> result = null;
            // Nalezení prvku v levém podstromu
            if (root.Left != null)
                result = FindUsingDFS(root.Left, value);
            // Pokud není prvek v pravém podstromu, pokusím se jej nalézt v pravém.
            if (result == null && root.Right != null)
                result = FindUsingDFS(root.Right, value);
            return result;
        }

        /// <summary>
        /// DFS pomocí zásobníku.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Node<int> FindUsingDFS2(Node<int> root, int value)
        {
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(root);

            while (true)
            {
                Node<int> actual = stack.Pop();

                if (actual.Value == value)
                    return actual;

                // Přidám pravého potomka do zásobníku
                if (actual.Right != null)
                    stack.Push(actual.Right);
                // a pak přidám levého potomka => levý potomek bude na vrcholu zásobníku
                if (actual.Left != null)
                    stack.Push(actual.Left);
            }
        }
    }
}
