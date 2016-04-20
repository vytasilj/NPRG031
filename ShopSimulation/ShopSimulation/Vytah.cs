using System;
using System.Collections.Generic;

namespace ShopSimulation
{
    public class Vytah : Proces
    {
        private readonly int _kapacita;
        private readonly int _dobaNastupu;
        private readonly int _dobaVystupu;
        private readonly int _dobaPatro2Patro;
        static readonly int[] ismery = { +1, -1, 0 }; // prevod (int) SmeryJizdy na smer


        private class Pasazer
        {
            public Proces kdo;
            public int kamJede;


            public Pasazer(Proces kdo, int kamJede)
            {
                this.kdo = kdo;
                this.kamJede = kamJede;
            }
        }


        private readonly List<Pasazer>[,] _cekatele; // [patro,smer]
        private readonly List<Pasazer> _naklad;   // pasazeri ve vytahu
        private SmeryJizdy _smer;
        private int _kdyJsemMenilSmer;
        

        public Vytah(Model model, string popis)
        {
            this.model = model;
            string[] popisy = popis.Split(mezery, StringSplitOptions.RemoveEmptyEntries);
            ID = popisy[0];
            _kapacita = int.Parse(popisy[1]);
            _dobaNastupu = int.Parse(popisy[2]);
            _dobaVystupu = int.Parse(popisy[3]);
            _dobaPatro2Patro = int.Parse(popisy[4]);
            patro = 0;
            _smer = SmeryJizdy.Stoji;
            _kdyJsemMenilSmer = -1;

            _cekatele = new List<Pasazer>[model.MaxPatro + 1, 2];
            for (int i = 0; i < model.MaxPatro + 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    _cekatele[i, j] = new List<Pasazer>();
                }

            }
            _naklad = new List<Pasazer>();
        }


        public void PridejDoFronty(int odkud, int kam, Proces kdo)
        {
            Pasazer pas = new Pasazer(kdo, kam);
            if (kam > odkud)
                _cekatele[odkud, (int)SmeryJizdy.Nahoru].Add(pas);
            else
                _cekatele[odkud, (int)SmeryJizdy.Dolu].Add(pas);

            // pripadne rozjet stojici vytah:
            if (_smer == SmeryJizdy.Stoji)
            {
                model.Odplanuj(model.vytah, TypUdalosti.Start); // kdyby nahodou uz byl naplanovany
                model.Naplanuj(model.Cas, this, TypUdalosti.Start);
            }
        }


        public bool CekaNekdoVPatrechVeSmeruJizdy()
        {
            int ismer = ismery[(int)_smer];
            for (int pat = patro + ismer; (pat > 0) && (pat <= model.MaxPatro); pat += ismer)
                if ((_cekatele[pat, (int)SmeryJizdy.Nahoru].Count > 0) || (_cekatele[pat, (int)SmeryJizdy.Dolu].Count > 0))
                {
                    if (_cekatele[pat, (int)SmeryJizdy.Nahoru].Count > 0)
                        log("Nahoru ceka " + _cekatele[pat, (int)SmeryJizdy.Nahoru][0].kdo.ID
                            + " v patre " + pat + "/" + _cekatele[pat, (int)SmeryJizdy.Nahoru][0].kdo.patro);
                    if (_cekatele[pat, (int)SmeryJizdy.Dolu].Count > 0)
                        log("Dolu ceka " + _cekatele[pat, (int)SmeryJizdy.Dolu][0].kdo.ID
                            + " v patre " + pat + "/" + _cekatele[pat, (int)SmeryJizdy.Dolu][0].kdo.patro);

                    //log(" x "+cekatele[pat, (int)SmeryJizdy.Nahoru].Count+" x "+cekatele[pat, (int)SmeryJizdy.Dolu].Count);
                    return true;
                }
            return false;
        }

        public override void Zpracuj(Udalost ud)
        {
            switch (ud.co)
            {
                case TypUdalosti.Start:

                    // HACK pro cerstve probuzeny vytah:
                    if (_smer == SmeryJizdy.Stoji)
                        // stoji, tedy nikoho neveze a nekdo ho prave probudil => nastavim jakykoliv smer a najde ho:
                        _smer = SmeryJizdy.Nahoru;

                    // chce nekdo vystoupit?
                    foreach (Pasazer pas in _naklad)
                        if (pas.kamJede == patro)
                            // bude vystupovat:
                        {
                            _naklad.Remove(pas);

                            pas.kdo.patro = patro;
                            model.Naplanuj(model.Cas + _dobaVystupu, pas.kdo, TypUdalosti.Start);
                            log("vystupuje " + pas.kdo.ID);

                            model.Naplanuj(model.Cas + _dobaVystupu, this, TypUdalosti.Start);

                            return; // to je pro tuhle chvili vsechno
                        }

                    // muze a chce nekdo nastoupit?
                    if (_naklad.Count == _kapacita)
                        // i kdyby chtel nekdo nastupovat, nemuze; veze lidi => pokracuje:
                    {
                        // popojet:
                        int ismer = ismery[(int)_smer];
                        patro = patro + ismer;

                        string spas = "";
                        foreach (Pasazer pas in _naklad)
                            spas += " " + pas.kdo.ID;
                        log("odjizdim");
                        model.Naplanuj(model.Cas + _dobaPatro2Patro, this, TypUdalosti.Start);
                        return; // to je pro tuhle chvili vsechno
                    }
                    else
                    // neni uplne plny
                    {
                        // chce nastoupit nekdo VE SMERU jizdy?
                        if (_cekatele[patro, (int)_smer].Count > 0)
                        {
                            log("nastupuje " + _cekatele[patro, (int)_smer][0].kdo.ID);
                            _naklad.Add(_cekatele[patro, (int)_smer][0]);
                            _cekatele[patro, (int)_smer].RemoveAt(0);
                            model.Naplanuj(model.Cas + _dobaNastupu, this, TypUdalosti.Start);

                            return; // to je pro tuhle chvili vsechno
                        }

                        // ve smeru jizdy nikdo nenastupuje:
                        if (_naklad.Count > 0)
                            // nikdo nenastupuje, vezu pasazery => pokracuju v jizde:
                        {
                            // popojet:
                            int ismer = ismery[(int)_smer];
                            patro = patro + ismer;

                            string spas = "";
                            foreach (Pasazer pas in _naklad)
                                spas += " " + pas.kdo.ID;
                            //log("nekoho vezu");
                            log("odjizdim: " + spas);

                            model.Naplanuj(model.Cas + _dobaPatro2Patro, this, TypUdalosti.Start);
                            return; // to je pro tuhle chvili vsechno
                        }

                        // vytah je prazdny, pokud v dalsich patrech ve smeru jizdy uz nikdo neceka, muze zmenit smer nebo se zastavit:
                        if (CekaNekdoVPatrechVeSmeruJizdy() == true)
                            // pokracuje v jizde:
                        {
                            // popojet:
                            int ismer = ismery[(int)_smer];
                            patro = patro + ismer;

                            //log("nekdo ceka");
                            log("odjizdim");
                            model.Naplanuj(model.Cas + _dobaPatro2Patro, this, TypUdalosti.Start);
                            return; // to je pro tuhle chvili vsechno
                        }

                        // ve smeru jizdy uz nikdo neceka => zmenit smer nebo zastavit:
                        if (_smer == SmeryJizdy.Nahoru)
                            _smer = SmeryJizdy.Dolu;
                        else
                            _smer = SmeryJizdy.Nahoru;

                        log("zmena smeru");

                        //chce nekdo nastoupit prave tady?
                        if (_kdyJsemMenilSmer != model.Cas)
                        {
                            _kdyJsemMenilSmer = model.Cas;
                            // podivat se, jestli nekdo nechce nastoupi opacnym smerem:
                            model.Naplanuj(model.Cas, this, TypUdalosti.Start);
                            return;
                        }

                        // uz jsem jednou smer menil a zase nikdo nenastoupil a nechce => zastavit
                        log("zastavuje");
                        _smer = SmeryJizdy.Stoji;
                        return; // to je pro tuhle chvili vsechno
                    }
            }
        }
    }
}