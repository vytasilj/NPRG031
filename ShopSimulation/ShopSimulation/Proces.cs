using System;

namespace ShopSimulation
{
    public abstract class Proces
    {
        public static char[] mezery = { ' ' };
        public int patro;
        public string ID;
        public abstract void Zpracuj(Udalost ud);


        public void log(string zprava)
        {
            //if (ID == "Dana")
            //if (ID == "elefant")
            //if (this is Zakaznik)
            Console.WriteLine("{0}/{3} {1}: {2}",
                model.Cas, ID, zprava, patro);
        }


        protected Model model;
    }
}