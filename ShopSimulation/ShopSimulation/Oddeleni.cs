using System;
using System.Collections.Generic;

namespace ShopSimulation
{
    public class Oddeleni : Proces
    {
        private readonly int _rychlost;
        private readonly List<Zakaznik> _fronta;
        private bool _obsluhuje;


        public Oddeleni(Model model, string popis)
        {
            this.model = model;
            string[] popisy = popis.Split(mezery, StringSplitOptions.RemoveEmptyEntries);
            ID = popisy[0];
            patro = int.Parse(popisy[1]);
            if (patro > model.MaxPatro)
                model.MaxPatro = patro;
            _rychlost = int.Parse(popisy[2]);
            _obsluhuje = false;
            _fronta = new List<Zakaznik>();
            model.VsechnaOddeleni.Add(this);
        }


        public void ZaradDoFronty(Zakaznik zak)
        {
            _fronta.Add(zak);
            log("do fronty " + zak.ID);

            if (_obsluhuje) ; // nic
            else
            {
                _obsluhuje = true;
                model.Naplanuj(model.Cas, this, TypUdalosti.Start);
            }
        }

        public void VyradZFronty(Zakaznik koho)
        {
            foreach (Zakaznik zak in _fronta)
                if (zak == koho)
                {
                    _fronta.Remove(zak);
                    return;
                }
        }

        public override void Zpracuj(Udalost ud)
        {
            switch (ud.co)
            {
                case TypUdalosti.Start:
                    if (_fronta.Count == 0)
                        _obsluhuje = false; // a dal neni naplanovana a probudi se tim, ze se nekdo zaradi do fronty
                    else
                    {
                        Zakaznik zak = _fronta[0];
                        _fronta.RemoveAt(0);
                        model.Odplanuj(zak, TypUdalosti.Trpelivost);
                        model.Naplanuj(model.Cas + _rychlost, zak, TypUdalosti.Obslouzen);
                        model.Naplanuj(model.Cas + _rychlost, this, TypUdalosti.Start);
                    }
                    break;
            }
        }
    }
}