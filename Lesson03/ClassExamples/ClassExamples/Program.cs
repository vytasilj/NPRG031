using System;
using System.Collections.Generic;

namespace ClassExamples
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        private static void AbstractInheritance()
        {
            List<AbstractInheritance.Shape> shapes = new List<AbstractInheritance.Shape>();

            // Naplnění seznamu
            shapes.Add(new AbstractInheritance.Rectangle(10, 12));
            //shapes.Add(new AbstractInheritance.Triangle());

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
            //shapes.Add(new InheritanceExample.Triangle());

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
            //shapes.Add(new InheritanceExample.Triangle());

            foreach (Interfaces.IShape shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }

        private static void MultipleInheritance()
        {
            MultipleInheritance.Rectangle rectangle = new MultipleInheritance.Rectangle(10, 20);
            //rectangle.GetArea22();
            ((MultipleInheritance.IShape2) rectangle).GetArea22();
        }
    }
}
