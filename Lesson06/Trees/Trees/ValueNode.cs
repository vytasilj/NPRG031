using System;

namespace Trees
{
    /// <summary>
    /// Prvek stromu, který obsahuje hodnotu.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueNode<T> where T : IComparable
    {
        public T Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}