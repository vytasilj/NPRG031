using System;

namespace KnapsackProblem
{
    public class Knapsack
    {
        public int Resolve(int itemsCount, int size, int[] weights, int[] values)
        {
            var matrix = new int[itemsCount + 1, size + 1];
            for (int i = 1; i <= itemsCount; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (weights[i - 1] <= j)
                        matrix[i, j] = Math.Max(matrix[i - 1, j], values[i - 1] + matrix[i - 1, j - weights[i - 1]]);
                    else
                        matrix[i, j] = matrix[i - 1, j];
                }
            }
            return matrix[itemsCount, size];
        }
    }
}