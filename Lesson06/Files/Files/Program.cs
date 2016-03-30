using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            // Na konci using sekce se reader i writer správně ukončí.
            using (StreamReader reader = new StreamReader("test"))
            using (StreamWriter writer = new StreamWriter("output"))
            {
                writer.WriteLine(reader.ReadLine());
            }
        }
    }
}
