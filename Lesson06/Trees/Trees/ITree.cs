using System;

namespace Trees
{
    public interface ITree<T> where T : IComparable
    {
        /// <summary>
        /// Přidání prvku do stromu.
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Nalezení prvku.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Vrátí nalezený prvek, nebo null.</returns>
        ITreeNode<T> Find(T value);

        /// <summary>
        /// Zjišťuje, zda je ve stromu daný prvek.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(T value);

        /// <summary>
        /// Odstranění prvku.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Remove(T value);

        /// <summary>
        /// Odstranění prvku.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Remove(ITreeNode<T> value);

        /// <summary>
        /// Vrácení prvku s minimální hodnotou.
        /// </summary>
        /// <returns></returns>
        ITreeNode<T> Min();

        /// <summary>
        /// Vrácení prvku s maximální hodnotou.
        /// </summary>
        /// <returns></returns>
        ITreeNode<T> Max();

        /// <summary>
        /// Metoda, která nalezne prvek, který následuje po prvku se zadanou hodnotou,
        /// nebo null, pokud takový prvek neexistuje.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ITreeNode<T> Succ(T value);

        /// <summary>
        /// Metoda, která nalezne prvek, který následuje po zadaném prvku,
        /// nebo null, pokud takový prvek neexistuje.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ITreeNode<T> Succ(ITreeNode<T> value);

        /// <summary>
        /// Metoda, která nalezne prvek, který předchází prvku se zadanou hodnotou,
        /// nebo null, pokud takový prvek neexistuje.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ITreeNode<T> Predec(T value);

        /// <summary>
        /// Metoda, která nalezne prvek, který předchází zadanému prvku,
        /// nebo null, pokud takový prvek neexistuje.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ITreeNode<T> Predec(ITreeNode<T> value);
    }
}