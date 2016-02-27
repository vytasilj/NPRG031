using System;
using System.Collections.Generic;

namespace Collections
{
    public static class Lists
    {
        public static List<int> CreateDefaultList(int size)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < size; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static void ForeachError()
        {
            List<int> list = CreateDefaultList(10);

            foreach (int item in list)
            {
                // Chyba, nelze měnit seznam v cyklu foreach
                list.Remove(item);
            }
        }

        public static void ForError()
        {
            List<int> list = CreateDefaultList(10);

            // Uložím si velikost seznamu do proměnné
            int count = list.Count;
            // count je původní počet prvků v seznamu, po změně se nemodifikuje
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(list[i]);
                if (i == 0)
                    list.RemoveAt(i);
            }
        }

        public static void ForNoError()
        {
            List<int> list = CreateDefaultList(10);

            // Zde se porovnává s velikostí seznamu
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                if (i == 0)
                    list.RemoveAt(i);
            }
        }
    }
}