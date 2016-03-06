using System.Collections.Generic;

namespace Search.Tree
{
    public class Node<T>
    {
        private readonly T _value;

        private Node<T> _parent;
        private Node<T> _left;
        private Node<T> _right;
        

        public Node(T value)
        {
            _value = value;
        }


        /// <summary>
        /// Hodnota prvku stromu.
        /// </summary>
        public T Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Rodič aktuálního prvku.
        /// </summary>
        public Node<T> Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        /// <summary>
        /// Levý potomek.
        /// </summary>
        public Node<T> Left
        {
            get { return _left; }
            private set { _left = value; }
        }

        /// <summary>
        /// PRavý potomek.
        /// </summary>
        public Node<T> Right
        {
            get { return _right; }
            private set { _right = value; }
        }
        
        public bool IsRoot
        {
            get { return _parent == null; }
        }

        public bool IsLeaf
        {
            get { return _left == null && _right == null; }
        }


        public void Add(T item)
        {
            Node<T> node = GetItemWithMaxOneChild(this);
            Node<T> child = new Node<T>(item);
            if (node.Left == null)
                node.Left = child;
            else if (node.Right == null)
                node.Right = child;
            child.Parent = node;
        }

        /// <summary>
        /// Nalezení prvku s maximálně jedním potomkem.
        /// Používá BFS.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static Node<T> GetItemWithMaxOneChild(Node<T> root)
        {
            List<Node<T>> items = new List<Node<T>>();
            items.Add(root);

            while (items.Count > 0)
            {
                Node<T> first = items[0];
                items.RemoveAt(0);

                if (first.Left == null || first.Right == null)
                    return first;

                items.Add(first.Left);
                items.Add(first.Right);
            }
            return null;
        }
    }
}