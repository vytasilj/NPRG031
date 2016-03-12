namespace ClassExamples.MultipleInheritance
{
    /// <summary>
    /// Třída je potomkem třídy Shape a implementuje interface IShape2.
    /// Třídy nemohou dědit od více tříd.
    /// <example>
    /// Příklad dědění třídy a interfacy.
    /// Třída : BaseTřída, Interface1, Interface2
    /// 
    /// Nelze provést:
    /// Třída : Interface1, BaseTřída
    /// 
    /// Pokud třída dědí od jiné třídy, musí být tato třída jako první za ':'.
    /// </example>
    /// </summary>
    public class Rectangle : Shape, IShape2
    {
        public Rectangle(double height, double width) : base(height, width)
        {
        }

        public override double GetArea()
        {
            return _height * _width;
        }

        public double GetArea2()
        {
            return _height * _width;
        }

        /// <summary>
        /// Explicitní implementace metody z interfacu.
        /// Lze na tuto metodu přistoupit jen přes interface.
        /// </summary>
        /// <returns></returns>
        double IShape2.GetArea22()
        {
            return GetArea2();
        }
    }
}