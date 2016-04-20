using System;

namespace ShopSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();
            Console.Write("{0} KONEC --------------------------------", model.Vypocet());
            Console.ReadLine();
        }
    }
}