using System;
using System.Collections.Generic;

namespace ShopSimulation
{
    public class Kalendar
    {
        private readonly List<Udalost> _seznam;


        public Kalendar()
        {
            _seznam = new List<Udalost>();
        }


        public void Pridej(int kdy, Proces kdo, TypUdalosti co)
        {
            //Console.WriteLine("PLAN: {0} {1} {2}", kdy, kdo.ID, co);
            // pro hledani chyby:
            foreach (Udalost ud in _seznam)
                if (ud.kdo == kdo)
                    Console.WriteLine("");


            _seznam.Add(new Udalost(kdy, kdo, co));
        }


        public void Odeber(Proces kdo, TypUdalosti co)
        {
            foreach (Udalost ud in _seznam)
            {
                if ((ud.kdo == kdo) && (ud.co == co))
                {
                    _seznam.Remove(ud);
                    return; // odebiram jen jeden vyskyt!
                }
            }
        }


        public Udalost Prvni()
        {
            Udalost prvni = null;
            foreach (Udalost ud in _seznam)
                if ((prvni == null) || (ud.kdy < prvni.kdy))
                    prvni = ud;
            _seznam.Remove(prvni);
            return prvni;
        }


        public Udalost Vyber()
        {
            return Prvni();
        }
    }
}