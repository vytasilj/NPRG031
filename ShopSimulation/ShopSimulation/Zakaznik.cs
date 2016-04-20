using System;
using System.Collections.Generic;

namespace ShopSimulation
{
    public class Zakaznik : Proces
    {
        private readonly int _trpelivost;
        private readonly int _prichod;
        private readonly List<string> _nakupy;


        public Zakaznik(Model model, string popis)
        {
            this.model = model;
            string[] popisy = popis.Split(mezery, StringSplitOptions.RemoveEmptyEntries);
            ID = popisy[0];
            _prichod = int.Parse(popisy[1]);
            _trpelivost = int.Parse(popisy[2]);
            _nakupy = new List<string>();
            for (int i = 3; i < popisy.Length; i++)
            {
                _nakupy.Add(popisy[i]);
            }
            this.patro = 0;
            Console.WriteLine("Init Zakaznik: {0}", ID);
            model.Naplanuj(_prichod, this, TypUdalosti.Start);
        }


        public override void Zpracuj(Udalost ud)
        {
            switch (ud.co)
            {
                case TypUdalosti.Start:
                    if (_nakupy.Count == 0)
                        // ma nakoupeno
                    {
                        if (patro == 0)
                            log("-------------- odchází"); // nic, konci
                        else
                            model.vytah.PridejDoFronty(patro, 0, this);
                    }
                    else
                    {
                        Oddeleni odd = OddeleniPodleJmena(_nakupy[0]);
                        int pat = odd.patro;
                        if (pat == patro) // to oddeleni je v patre, kde prave jsem
                        {
                            if (_nakupy.Count > 1)
                                model.Naplanuj(model.Cas + _trpelivost, this, TypUdalosti.Trpelivost);
                            odd.ZaradDoFronty(this);
                        }
                        else
                            model.vytah.PridejDoFronty(patro, pat, this);
                    }
                    break;

                case TypUdalosti.Obslouzen:
                    log("Nakoupeno: " + _nakupy[0]);
                    _nakupy.RemoveAt(0);
                    // ...a budu hledat dalsi nakup -->> Start
                    model.Naplanuj(model.Cas, this, TypUdalosti.Start);
                    break;

                case TypUdalosti.Trpelivost:
                    // vyradit z fronty:
                {
                    Oddeleni odd = OddeleniPodleJmena(_nakupy[0]);
                    odd.VyradZFronty(this);
                }

                // prehodit tenhle nakup na konec:
                    string nesplneny = _nakupy[0];
                    _nakupy.RemoveAt(0);
                    _nakupy.Add(nesplneny);

                    // ...a budu hledat dalsi nakup -->> Start
                    model.Naplanuj(model.Cas, this, TypUdalosti.Start);
                    break;
            }
        }

        private Oddeleni OddeleniPodleJmena(string kamChci)
        {
            foreach (Oddeleni odd in model.VsechnaOddeleni)
                if (odd.ID == kamChci)
                    return odd;
            return null;
        }
    }
}