using System.Collections.Generic;
using System.Text;

namespace ShopSimulation
{
    public class Model
    {
        public int Cas;
        public Vytah vytah;
        public List<Oddeleni> VsechnaOddeleni = new List<Oddeleni>();
        public int MaxPatro;
        private Kalendar kalendar;


        public void Naplanuj(int kdy, Proces kdo, TypUdalosti co)
        {
            kalendar.Pridej(kdy, kdo, co);
        }

        public void Odplanuj(Proces kdo, TypUdalosti co)
        {
            kalendar.Odeber(kdo, co);
        }

        public void VytvorProcesy()
        {
            System.IO.StreamReader soubor = new System.IO.StreamReader("obchod_data.txt", Encoding.GetEncoding(1250));
            while (!soubor.EndOfStream)
            {
                string s = soubor.ReadLine();
                if (s != "")
                {
                    switch (s[0])
                    {
                        case 'O':
                            new Oddeleni(this, s.Substring(1));
                            break;
                        case 'Z':
                            new Zakaznik(this, s.Substring(1));
                            break;
                        case 'V':
                            vytah = new Vytah(this, s.Substring(1));
                            break;
                    }
                }
            }
            soubor.Close();
        }

        public int Vypocet()
        {
            Cas = 0;
            kalendar = new Kalendar();
            VytvorProcesy();

            Udalost ud;

            while ((ud = kalendar.Vyber()) != null)
            {
                //Console.WriteLine("{0} {1} {2}", ud.kdy, ud.kdo.ID, ud.co);
                Cas = ud.kdy;
                ud.kdo.Zpracuj(ud);
            }
            return Cas;
        }
    }
}