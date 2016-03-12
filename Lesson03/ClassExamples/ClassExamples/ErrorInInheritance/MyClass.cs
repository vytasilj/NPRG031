using System;

namespace ClassExamples.ErrorInInheritance
{
    public class MyClass : BaseClass
    {
        private readonly bool _myClassInitialized;

        public MyClass(string message) : base(message)
        {
            _myClassInitialized = true;
            Console.WriteLine("MyClassCtor: {0}", message);
        }


        protected override void Do()
        {
            if (!_myClassInitialized)
                throw new NotSupportedException("This class is not initialized");

            Console.WriteLine("MyClassDo");
        }
    }
}