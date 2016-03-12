using System;
using System.Runtime.Serialization;

namespace ClassExamples.ExceptionInheritance
{
    /// <summary>
    /// Ukázka vytvoření vlastní exceptiony.
    /// </summary>
    public class MyException : Exception
    {
        public MyException() : base()
        {
        }

        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}