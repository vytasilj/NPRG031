namespace ClassExamples.AbstractInheritance
{
    public class Triangle : Shape
    {
        public Triangle(double height, double width) : base(height, width)
        {
        }

        public override double GetArea()
        {
            return _width * _height / 2;
        }
    }
}