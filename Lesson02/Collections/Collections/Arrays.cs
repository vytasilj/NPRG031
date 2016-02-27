using System;

namespace Collections
{
    /// <summary>
    /// Zde si ukážeme, jak se dá pracovat s poli.
    /// Pole má pevnou velikost.
    /// </summary>
    public static class Arrays
    {
        public static int[] GetSingleArray(int size)
        {
            return new int[size];
        }

        public static int[,] GetTwoDimensionalArray(int first, int second)
        {
            int[,] array = new int[first, second];
            Console.WriteLine(array[0, 0]);
            return array;
        }

        public static int[][] GetArrayOfArrays(int first, int innerSize)
        {
            int[][] array = new int[first][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[innerSize];
            }
            // Vypsání prvního prvku
            Console.WriteLine(array[0][0]);

            return array;
        }

        public static int[] AddToArray(int[] array, int item)
        {
            // Vytvoření nového pole, které je o 1 delší
            int[] result = new int[array.Length + 1];
            // Zkopírování array do result na index 0 a dále
            array.CopyTo(result, 0);
            // item vložíme na poslední místo pole
            result[array.Length] = item;
            // Vrátíme pole
            return result;
        }

        public static int[] RemoveLastItem(int[] array)
        {
            int[] result = new int[array.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[i];
            }
            return result;
            // Pro změnu velikosti pole lze použít i Array.Resize(ref array, int newSize).
            // Resize vytvoří nové pole požadované délky a prvky do něj zkopíruje.
            // Array.Resize(ref array, array.Length - 1);
        }
    }
}