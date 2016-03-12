namespace ClassExamples.AbstractInheritance
{
    public abstract class Shape
    {
        protected readonly double _height;
        protected readonly double _width;


        /// <summary>
        /// Konstruktor stačí protected, protože nelze vytvářet instance abstraktní třídy.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        protected Shape(double height, double width)
        {
            _height = height;
            _width = width;
        }


        /// <summary>
        /// Abstraktní metoda => potomci ji MUSÍ implementovat.
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();
    }
}