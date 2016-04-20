using System;
using System.Collections.Generic;

namespace ShopSimulation
{
    public class Vytah : Proces
    {
        private int kapacita;
        private int dobaNastupu;
        private int dobaVystupu;
        private int dobaPatro2Patro;
        static int[] ismery = { +1, -1, 0 }; // prevod (int) SmeryJizdy na smer

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

        private List<Pasazer>[,] cekatele; // [patro,smer]
        private List<Pasazer> naklad;   // pasazeri ve vytahu
        private SmeryJizdy smer;
        private int kdyJsemMenilSmer;

        public void PridejDoFronty(int odkud, int kam, Proces kdo)
        {
            Pasazer pas = new Pasazer(kdo, kam);
            if (kam > odkud)
                cekatele[odkud, (int)SmeryJizdy.Nahoru].Add(pas);
            else
                cekatele[odkud, (int)SmeryJizdy.Dolu].Add(pas);

            // pripadne rozjet stojici vytah:
            if (smer == SmeryJizdy.Stoji)
            {
                model.Odplanuj(model.vytah, TypUdalosti.Start); // kdyby nahodou uz byl naplanovany
                model.Naplanuj(model.Cas, this, TypUdalosti.Start);
            }
        }
        public bool CekaNekdoVPatrechVeSmeruJizdy()
        {
            int ismer = ismery[(int)smer];
            for (int pat = patro + ismer; (pat > 0) && (pat <= model.MaxPatro); pat += ismer)
                if ((cekatele[pat, (int)SmeryJizdy.Nahoru].Count > 0) || (cekatele[pat, (int)SmeryJizdy.Dolu].Count > 0))
                {
                    if (cekatele[pat, (int)SmeryJizdy.Nahoru].Count > 0)
                        log("Nahoru ceka " + cekatele[pat, (int)SmeryJizdy.Nahoru][0].kdo.ID
                            + " v patre " + pat + "/" + cekatele[pat, (int)SmeryJizdy.Nahoru][0].kdo.patro);
                    if (cekatele[pat, (int)SmeryJizdy.Dolu].Count > 0)
                        log("Dolu ceka " + cekatele[pat, (int)SmeryJizdy.Dolu][0].kdo.ID
                            + " v patre " + pat + "/" + cekatele[pat, (int)SmeryJizdy.Dolu][0].kdo.patro);

                    //log(" x "+cekatele[pat, (int)SmeryJizdy.Nahoru].Count+" x "+cekatele[pat, (int)SmeryJizdy.Dolu].Count);
                    return true;
                }
            return false;
        }

        public Vytah(Model model, string popis)
        {
            this.model = model;
            string[] popisy = popis.Split(Proces.mezery, StringSplitOptions.RemoveEmptyEntries);
            this.ID = popisy[0];
            this.kapacita = int.Parse(popisy[1]);
            this.dobaNastupu = int.Parse(popisy[2]);
            this.dobaVystupu = int.Parse(popisy[3]);
            this.dobaPatro2Patro = int.Parse(popisy[4]);
            this.patro = 0;
            this.smer = SmeryJizdy.Stoji;
            this.kdyJsemMenilSmer = -1;

            cekatele = new List<Pasazer>[model.MaxPatro + 1, 2];
            for (int i = 0; i < model.MaxPatro + 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cekatele[i, j] = new List<Pasazer>();
                }

            }
            naklad = new List<Pasazer>();
        }
        public override void Zpracuj(Udalost ud)
        {
            switch (ud.co)
            {
                case TypUdalosti.Start:

                    // HACK pro cerstve probuzeny vytah:
                    if (smer == SmeryJizdy.Stoji)
                        // stoji, tedy nikoho neveze a nekdo ho prave probudil => nastavim jakykoliv smer a najde ho:
                        smer = SmeryJizdy.Nahoru;

                    // chce nekdo vystoupit?
                    foreach (Pasazer pas in naklad)
                        if (pas.kamJede == patro)
                            // bude vystupovat:
                        {
                            naklad.Remove(pas);

                            pas.kdo.patro = patro;
                            model.Naplanuj(model.Cas + dobaVystupu, pas.kdo, TypUdalosti.Start);
                            log("vystupuje " + pas.kdo.ID);

                            model.Naplanuj(model.Cas + dobaVystupu, this, TypUdalosti.Start);

                            return; // to je pro tuhle chvili vsechno
                        }

                    // muze a chce nekdo nastoupit?
                    if (naklad.Count == kapacita)
                        // i kdyby chtel nekdo nastupovat, nemuze; veze lidi => pokracuje:
                    {
                        // popojet:
                        int ismer = ismery[(int)smer];
                        patro = patro + ismer;

                        string spas = "";
                        foreach (Pasazer pas in naklad)
                            spas += " " + pas.kdo.ID;
                        log("odjizdim");
                        model.Naplanuj(model.Cas + dobaPatro2Patro, this, TypUdalosti.Start);
                        return; // to je pro tuhle chvili vsechno
                    }
                    else
                    // neni uplne plny
                    {
                        // chce nastoupit nekdo VE SMERU jizdy?
                        if (cekatele[patro, (int)smer].Count > 0)
                        {
                            log("nastupuje " + cekatele[patro, (int)smer][0].kdo.ID);
                            naklad.Add(cekatele[patro, (int)smer][0]);
                            cekatele[patro, (int)smer].RemoveAt(0);
                            model.Naplanuj(model.Cas + dobaNastupu, this, TypUdalosti.Start);

                            return; // to je pro tuhle chvili vsechno
                        }

                        // ve smeru jizdy nikdo nenastupuje:
                        if (naklad.Count > 0)
                            // nikdo nenastupuje, vezu pasazery => pokracuju v jizde:
                        {
                            // popojet:
                            int ismer = ismery[(int)smer];
                            patro = patro + ismer;

                            string spas = "";
                            foreach (Pasazer pas in naklad)
                                spas += " " + pas.kdo.ID;
                            //log("nekoho vezu");
                            log("odjizdim: " + spas);

                            model.Naplanuj(model.Cas + dobaPatro2Patro, this, TypUdalosti.Start);
                            return; // to je pro tuhle chvili vsechno
                        }

                        // vytah je prazdny, pokud v dalsich patrech ve smeru jizdy uz nikdo neceka, muze zmenit smer nebo se zastavit:
                        if (CekaNekdoVPatrechVeSmeruJizdy() == true)
                            // pokracuje v jizde:
                        {
                            // popojet:
                            int ismer = ismery[(int)smer];
                            patro = patro + ismer;

                            //log("nekdo ceka");
                            log("odjizdim");
                            model.Naplanuj(model.Cas + dobaPatro2Patro, this, TypUdalosti.Start);
                            return; // to je pro tuhle chvili vsechno
                        }

                        // ve smeru jizdy uz nikdo neceka => zmenit smer nebo zastavit:
                        if (smer == SmeryJizdy.Nahoru)
                            smer = SmeryJizdy.Dolu;
                        else
                            smer = SmeryJizdy.Nahoru;

                        log("zmena smeru");

                        //chce nekdo nastoupit prave tady?
                        if (kdyJsemMenilSmer != model.Cas)
                        {
                            kdyJsemMenilSmer = model.Cas;
                            // podivat se, jestli nekdo nechce nastoupi opacnym smerem:
                            model.Naplanuj(model.Cas, this, TypUdalosti.Start);
                            return;
                        }

                        // uz jsem jednou smer menil a zase nikdo nenastoupil a nechce => zastavit
                        log("zastavuje");
                        smer = SmeryJizdy.Stoji;
                        return; // to je pro tuhle chvili vsechno
                    }
            }
        }
    }
}