using System;

namespace ClassExamples.InheritanceExample
{
    public class Shape
    {
        protected readonly double _height;
        protected readonly double _width;


        public Shape(double height, double width)
        {
            _height = height;
            _width = width;
        }


        /// <summary>
        /// Virtuální metoda => nemusí být přepsána v potomcích.
        /// </summary>
        /// <returns></returns>
        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
