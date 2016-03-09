using System;
using System.Globalization;

namespace ClassExamples.Polymorphism
{
    /// <summary>
    /// Třída s polymorfismem.
    /// Standardní formátovací stringy pro čísla:
    /// https://msdn.microsoft.com/cs-cz/library/dwhawy9k(v=vs.110).aspx
    /// </summary>
    public class ConvertToStringExample
    {
        /// <summary>
        /// int => string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertToString(int number)
        {
            Console.WriteLine("ConvertToString with int");
            return number.ToString();
        }

        /// <summary>
        /// double => string. Závislé na culture (desetinná tečka, ...).
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertToString(double number)
        {
            Console.WriteLine("ConvertToString with double");
            return number.ToString(CultureInfo.CurrentCulture);
        }

        public string ConvertToString(decimal number)
        {
            Console.WriteLine("ConvertToString with decimal");
            return number.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// double => string. Nezávislé na culture.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertToString(float number)
        {
            Console.WriteLine("ConvertToString with float");
            return number.ToString();
        }

        public string ConvertToString(long number)
        {
            Console.WriteLine("ConvertToString with long (Int64)");
            return number.ToString();
        }

        public string ConvertToString(ulong number)
        {
            Console.WriteLine("ConvertToString with ulong (UInt64)");
            return number.ToString();
        }
    }
}