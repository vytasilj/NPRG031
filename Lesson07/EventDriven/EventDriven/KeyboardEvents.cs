using System;
using System.Collections.Generic;

namespace EventDriven
{
    public class KeyboardEvents
    {
        private readonly Dictionary<string, string> _savedMessages;


        public KeyboardEvents()
        {
            _savedMessages = new Dictionary<string, string>();
        }


        public static bool IsExitText(string text)
        {
            return text == "e" || text == "exit";
        }


        public void Work(string text)
        {
            string[] strings = text.Split(new [] {'"'}, StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length < 1 || strings.Length > 2)
                return;
            string[] split = strings[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length < 1 || strings.Length > 2)
                return;
            string command = split[0];
            switch (command)
            {
                case "s":
                case "save":
                    if (!CheckLength(split, 2) || !CheckLength(strings, 2))
                        return;
                    SaveMessage(split[1], strings[1]);
                    break;

                case "l":
                case "load":
                    if (!CheckLength(split, 2))
                        return;
                    LoadMessage(split[1]);
                    break;

                case "d":
                case "delete":
                    if (!CheckLength(split, 2))
                        return;
                    DeleteMessage(split[1]);
                    break;

                case "u":
                case "update":
                    if (!CheckLength(split, 2) || !CheckLength(strings, 2))
                        return;
                    UpdateMessage(split[1], strings[1]);
                    break;

                case "h":
                case "help":
                    WriteHelp();
                    break;

                case "list":
                    ListMessages();
                    break;

                default:
                    Console.WriteLine("Neznámý příkaz. Použijte help.");
                    break;
            }
        }


        private void SaveMessage(string key, string text)
        {
            if (_savedMessages.ContainsKey(key))
            {
                Console.WriteLine("Zpráva s tímto id již existuje.");
                return;
            }

            _savedMessages.Add(key, text);
        }

        private void LoadMessage(string key)
        {
            string value;
            if (!TryGetMessage(key, out value))
                return;
            Console.WriteLine(value);
        }

        private void DeleteMessage(string key)
        {
            string value;
            if (!TryGetMessage(key, out value))
                return;
            _savedMessages.Remove(key);
        }

        private void UpdateMessage(string key, string text)
        {
            string value;
            if (!TryGetMessage(key, out value))
                return;
            _savedMessages[key] = text;
        }

        private void ListMessages()
        {
            foreach (KeyValuePair<string, string> message in _savedMessages)
            {
                Console.WriteLine("Key: {0} - Message: {1}", message.Key, message.Value);
            }
        }

        private void WriteHelp()
        {
            Console.WriteLine("Seznam příklazů:");
            Console.WriteLine("e, exit      => ukončení programu");
            Console.WriteLine("s, save      => uložení zprávy (s idZprávy \"textZprávy\")");
            Console.WriteLine("u, update    => uložení zprávy (u idZprávy \"textZprávy\")");
            Console.WriteLine("l, load      => načtení zprávy (l idZprávy)");
            Console.WriteLine("d, delete    => smazání zprávy (d idZprávy)");
            Console.WriteLine("list         => vypsání všech uložených zpráv");
        }

        private bool TryGetMessage(string key, out string value)
        {
            if (!_savedMessages.TryGetValue(key, out value))
            {
                Console.WriteLine("Neexistuje zpráva s id {0}", key);
                return false;
            }
            return true;
        }

        private bool CheckLength(string[] split, int length)
        {
            if (split.Length != length)
            {
                Console.WriteLine("Neplatná syntax. Použjte help.");
                return false;
            }
            return true;
        }
    }
}