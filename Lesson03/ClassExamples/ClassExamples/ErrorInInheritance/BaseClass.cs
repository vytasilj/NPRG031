using System;

namespace ClassExamples.ErrorInInheritance
{
    public class BaseClass
    {
        private readonly bool _baseClassInitialized;

        public BaseClass(string message)
        {
            _baseClassInitialized = true;
            Console.WriteLine("BaseClassCtor: {0}", message);
            
            Do();
        }


        protected virtual void Do()
        {
            if (!_baseClassInitialized)
                throw new NotSupportedException("This class is not initialized");

            Console.WriteLine("BaseClassDo");
        }
    }
}