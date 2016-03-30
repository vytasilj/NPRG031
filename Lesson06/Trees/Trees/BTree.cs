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

        public ITreeNode<T> Find(T value)
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

        public bool Remove(ITreeNode<T> value)
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Min()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Max()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Succ(T value)
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Succ(ITreeNode<T> value)
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Predec(T value)
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> Predec(ITreeNode<T> value)
        {
            throw new NotImplementedException();
        }
    }
}