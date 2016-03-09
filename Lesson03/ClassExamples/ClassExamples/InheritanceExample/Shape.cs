using System;

namespace ClassExamples.InheritanceExample
{
    public class Shape
    {
        protected double _height;
        protected double _width;


        public Shape(double height, double width)
        {
            _height = height;
            _width = width;
        }


        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
