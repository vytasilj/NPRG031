using System;

namespace FirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vypíše na konzoli Hello World! a odřádkuje.
            Console.WriteLine("Hello World!");

            // Zavolání metody Factorial s parametrem 10 => 10!.
            // Přiřžazení výsledku do proměnné factorial.
            int factorial = Factorial(10);
            Console.WriteLine(factorial);

            // Získání fibonaccioh čísla.
            int fibonacci = Fibonacci(10);

            // Následující region obsahuje ukázky cyklů.
            // Každá ukázka cyklu je v samostatné metodě.
            #region Příklady cyklů

            PrintSeparator();
            WhileCycle();
            PrintSeparator();
            DoWhileCycle();
            PrintSeparator();
            ForCycle();
            PrintSeparator();
            CompareWhileCycles();
            PrintSeparator();

            #endregion
            
            Console.WriteLine(DecimulToBinary(8));

            // Čtení s příkazové řádky.
            // Zde je kvůli tomu, aby se nezavřela konzole po skončení programu.
            Console.ReadLine();
        }


        /// <summary>
        /// Metoda pro výpočet faktoriálu.
        /// Ukázka metody a rekurze.
        /// </summary>
        /// <param name="n">n!</param>
        /// <returns></returns>
        static int Factorial(int n)
        {
            if (n == 1)
                return n;
            return n*Factorial(n - 1);
        }

        /// <summary>
        /// Získání i. fibonacciho čísla.
        /// Algoritmus je velmi neefektivní, na pozdějších cvičeních si ukážeme lepší algoritmus.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        static int Fibonacci(int i)
        {
            if (i == 0)
                return 0;
            if (i == 1)
                return 1;

            return Fibonacci(i - 1) + Fibonacci(i - 2);
        }

        /// <summary>
        /// While cyklus 0-9
        /// </summary>
        static void WhileCycle()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        
        /// <summary>
        /// Do-while 0-9
        /// </summary>
        static void DoWhileCycle()
        {
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);
        }

        /// <summary>
        /// For cyklus 0-9
        /// </summary>
        static void ForCycle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Ukázka rozdílu mezi whle cyklem a do-while cyklem.
        /// </summary>
        static void CompareWhileCycles()
        {
            while (false)
            {
                // Tato část kódu nikdy neproběhne
                Console.WriteLine("While cyklus");
            }

            do
            {
                // Tato část kódu proběhne jednou
                Console.WriteLine("Do-while cyklus");
            } while (false);
        }

        private static string DecimulToBinary(int number)
        {
            // prázdný string
            string result = "";

            while (number != 0)
            {
                result = result.Insert(0, (number%2).ToString());
                number /= 2;
            }

            // vrácení hodnoty z metody
            return result;
        }

        /// <summary>
        /// Metoda pro výpisu několika pomlček.
        /// </summary>
        private static void PrintSeparator()
        {
            Console.WriteLine("------------------------");
        }
    }
}
