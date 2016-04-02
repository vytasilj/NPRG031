using System;

namespace Trees
{
    /// <summary>
    /// Prvek stromu, který obsahuje hodnotu.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueNode<T> : ITreeNode<T>
    {
        public T Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}