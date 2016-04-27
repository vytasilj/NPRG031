using System;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemsCount = 4;
            int size = 10;
            int[] weights = {5, 4, 6, 3};
            int[] values = {10, 40, 30, 50};

            Console.WriteLine(new Knapsack().Resolve(itemsCount, size, weights, values));
            Console.ReadLine();
        }
    }
}
