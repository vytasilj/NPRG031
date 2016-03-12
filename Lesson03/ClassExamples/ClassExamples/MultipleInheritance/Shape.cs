namespace ClassExamples.MultipleInheritance
{
    public abstract class Shape
    {
        protected readonly double _height;
        protected readonly double _width;


        protected Shape(double height, double width)
        {
            _height = height;
            _width = width;
        }


        public abstract double GetArea();
    }
}