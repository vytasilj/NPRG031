using System.Collections.Generic;

namespace Lesson02.Tree
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


        public T Value
        {
            get { return _value; }
        }

        public Node<T> Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        public Node<T> Left
        {
            get { return _left; }
            private set { _left = value; }
        }

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
            Node<T> node = GetItemWithOneChild(this);
            Node<T> child = new Node<T>(item);
            if (node.Left == null)
                node.Left = child;
            else if (node.Right == null)
                node.Right = child;
            child.Parent = node;
        }

        private static Node<T> GetItemWithOneChild(Node<T> root)
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