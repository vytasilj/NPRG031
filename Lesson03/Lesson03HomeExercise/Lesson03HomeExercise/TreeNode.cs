using System;
using System.Collections.Generic;

namespace Lesson03HomeExercise
{
    public class TreeNode
    {
        private readonly int _value;

        private TreeNode _parent;
        private TreeNode _left;
        private TreeNode _right;


        public TreeNode(int value)
        {
            _value = value;
        }


        public int Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Properta ukazující na rodiče ve stromu.
        /// Propertu si lze představit jako dvě metody, jednu pro Get a druhou pro Set.
        ///  <example>
        /// <code>
        /// TreeNode x = Parent;
        /// - zde se volá get. Lze nahradit metodou GetParent();
        /// 
        /// Parent = new TreeNode();
        /// - zde se volá set. Lze nahradit metodou SetParent(new TreeNode());
        /// </code>
        /// </example>
        /// </summary>
        public TreeNode Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        public TreeNode Left
        {
            get { return _left; }
            private set { _left = value; }
        }

        public TreeNode Right
        {
            get { return _right; }
            private set { _right = value; }
        }


        public void Add(int item)
        {
            TreeNode node = GetItemWithMaxOneChild(this);
            TreeNode child = new TreeNode(item);
            if (node.Left == null)
                node.Left = child;
            else if (node.Right == null)
                node.Right = child;
            child.Parent = node;
        }

        /// <summary>
        /// Metoda, která vrátí TreeNode se zadanou hodnotou, jinak null.
        /// </summary>
        /// <param name="value">Hodnota, kterou hledáme.</param>
        /// <returns>Vrátí TreeNode, který jako Value má zadanou hodnotu. Pokud takový TreeNode neexistuje, vrátí null.</returns>
        public TreeNode Find(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Vrátí informaci o tom, zda je zadaná hodnota ve stromu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Odstranění prvku ze stromu.
        /// Je zde několik možných implementací, nepožaduji žádnou konkrétní.
        /// 
        /// Je potřeba si rozmyslet několik věcí:
        /// - odstranit všechny výskyty, nebo jen jeden (explicitně napsat při odevzdání, který to bude mazat),
        /// - Skutečně odstraním prvek, nebo jej nějak označím?
        ///     - Pokud si vyberete jen označení:
        ///         - jaké bude označení?
        ///         - Správně implementovat Find a Contains.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True => odstraněno, False => nic neodstraněno (není ve stromu).</returns>
        public bool Remove(int value)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Nalezení prvku s maximálně jedním potomkem.
        /// Používá BFS.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private TreeNode GetItemWithMaxOneChild(TreeNode root)
        {
            var items = new List<TreeNode>();
            items.Add(root);

            while (items.Count > 0)
            {
                TreeNode first = items[0];
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