namespace ClassExamples.MultipleInheritance
{
    public class Rectangle : Shape, IShape2
    {
        public Rectangle(double height, double width) : base(height, width)
        {
        }

        public override double GetArea()
        {
            return _height*_width;
        }

        public double GetArea2()
        {
            return _height * _width;
        }

        /// <summary>
        /// Explicitní implementace metody z interfacu.
        /// </summary>
        /// <returns></returns>
        double IShape2.GetArea22()
        {
            return GetArea2();
        }
    }
}