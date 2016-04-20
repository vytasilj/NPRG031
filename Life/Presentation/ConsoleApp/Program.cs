using System;
using kiswa.Games.Life.DataLayer;

namespace kiswa.Games.Life.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LifeGame lifeGame = new LifeGame(60, 40);   // 60x40 looks fairly square
            double lifeProbability = 0.25;
            lifeGame.Randomize(lifeProbability);

            bool exit = false;
            bool first = true;
            int genCount = 0;

            while (!exit)
            {
                Console.Clear();

                if (!first)
                {
                    lifeGame.Step();
                    genCount += 1;
                }
                first = false;

                Console.Write(lifeGame.ToString());
                Console.Write("Any key to continue, 'r' to randomize, 'q' to quit. Gen: " + genCount);

                char key = Console.ReadKey(false).KeyChar;
                if (key == 'q')
                {
                    exit = true;
                }
                else if (key == 'r')
                {
                    lifeGame.Randomize(lifeProbability);
                    first = true;
                    genCount = 0;
                    continue;
                }
            }
        }
    }
}
