namespace ClassExamples.AbstractInheritance
{
    public abstract class Shape
    {
        protected double _height;
        protected double _width;


        protected Shape(double height, double width)
        {
            _height = height;
            _width = width;
        }


        public abstract double GetArea();
    }
}