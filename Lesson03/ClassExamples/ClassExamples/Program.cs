using System;
using System.Collections.Generic;
using ClassExamples.ExceptionInheritance;

namespace ClassExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chyba. Metoda MyClass.Do() vyhodí NotSupportedException.
            //var myClass = new ErrorInInheritance.MyClass("message");

            AbstractInheritance();
            Inheritance();
            Interface();
            MultipleInheritance();

            try
            {
                // Vyhození MyException
                throw new MyException();
            }
            catch (MyException) // Odchycení jen MyExceptiony
            {
                Console.WriteLine("MyException");
                throw; // Poslání MyException dále do kódu
            }
            catch (Exception) // Odchytí vše
            {
                // Prázdný blok => tiché spolknutí chyby, nedoporučuje se.
            }
            finally // část kódu, která se provede po try i catch blocích
            {
                Console.WriteLine("Finally");
            }
        }


        private static void AbstractInheritance()
        {
            List<AbstractInheritance.Shape> shapes = new List<AbstractInheritance.Shape>();

            // Naplnění seznamu
            shapes.Add(new AbstractInheritance.Rectangle(10, 12));
            shapes.Add(new AbstractInheritance.Triangle(10, 12));

            foreach (AbstractInheritance.Shape shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }

        private static void Inheritance()
        {
            List<InheritanceExample.Shape> shapes = new List<InheritanceExample.Shape>();

            // Naplnění seznamu
            shapes.Add(new InheritanceExample.Rectangle(10, 12));
            shapes.Add(new InheritanceExample.Triangle(10, 12));

            foreach (InheritanceExample.Shape shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }

        private static void Interface()
        {
            List<Interfaces.IShape> shapes = new List<Interfaces.IShape>();

            // Naplnění seznamu
            shapes.Add(new Interfaces.Rectangle(10, 12));
            shapes.Add(new Interfaces.Triangle());

            foreach (Interfaces.IShape shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }

        private static void MultipleInheritance()
        {
            MultipleInheritance.Rectangle rectangle = new MultipleInheritance.Rectangle(10, 20);
            // MEtoda GetArea22() je definována jako explicitní, proto ji nemohu zvolat na Rectaglu, ale jen přes inteface.
            //rectangle.GetArea22();
            ((MultipleInheritance.IShape2) rectangle).GetArea22();
        }
    }
}
