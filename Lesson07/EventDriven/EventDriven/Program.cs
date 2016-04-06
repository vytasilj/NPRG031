using System;

namespace EventDriven
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyboardEvents events = new KeyboardEvents();
            while (true)
            {
                string line = Console.ReadLine();
                if (KeyboardEvents.IsExitText(line))
                    break;
                events.Work(line);
            }
        }
    }
}
