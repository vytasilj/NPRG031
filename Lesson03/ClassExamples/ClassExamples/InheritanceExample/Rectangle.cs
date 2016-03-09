namespace ClassExamples.InheritanceExample
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) : base(height, width)
        {
        }


        public override double GetArea()
        {
            return _height*_width;
        }
    }
}