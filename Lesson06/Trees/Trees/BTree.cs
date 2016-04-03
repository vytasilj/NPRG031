using System;

namespace Trees
{
    /// <summary>
    /// Implementace <seealso cref="ITree{T}"/>, která představuje B-strom.
    /// Více o B-stromech na přednáškách z Algoritmů a datových struktur.
    /// Například ve slidech od Hrice http://ktiml.ms.mff.cuni.cz/~hric/vyuka/alg/ads1pr.pdf
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BTree<T> : ITree<T> where T : IComparable
    {
        public BTree()
        {
        }


        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Find(T value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ValueNode<T> value)
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Min()
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Max()
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Succ(T value)
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Succ(ValueNode<T> value)
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Predec(T value)
        {
            throw new NotImplementedException();
        }

        public ValueNode<T> Predec(ValueNode<T> value)
        {
            throw new NotImplementedException();
        }
    }
}