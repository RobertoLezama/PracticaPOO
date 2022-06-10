using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO.UI
{
    internal class ConsoleMenu
    {
        private static int margen;
        private static bool f;

        internal static void CreateMenu(List<ConsoleMenuOption> options)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            ConsoleMenu.WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        ConsoleMenu.WriteMenu(options, options[index]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        ConsoleMenu.WriteMenu(options, options[index]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                switch (keyinfo.Key)
                {
                    case ConsoleKey.D1:

                        options[0].Selected.Invoke();
                        index = 0;
                        break;
                    case ConsoleKey.D2:
                        options[1].Selected.Invoke();
                        index = 0;
                        break;
                    case ConsoleKey.D3:
                        options[2].Selected.Invoke();
                        index = 0;
                        break;
                    case ConsoleKey.D4:
                        options[3].Selected.Invoke();
                        index = 0;
                        break;
                    default:
                        break;
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.Escape && keyinfo.Key != ConsoleKey.X);
        }

        internal static void WriteMenu(List<ConsoleMenuOption> options, ConsoleMenuOption selectedOption)
        {
            if (!f)
            {
                int lenght = options.Max(o => o.Name.Length);
                var template = "*  {0," + lenght + "}  *";
                margen = lenght + 6;

                for (int i = 0; i < options.Count; i++)
                {
                    options[i].Name = string.Format(template, options[i].Name);

                }
                f = true;
            }

           

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Console.WriteLine(new string('*',margen) );
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Console.WriteLine("*  Menu principal  *");
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Console.WriteLine(new string('*', margen));

            foreach (ConsoleMenuOption option in options)
            {
                if (option == selectedOption)
                {

                    //Console.Write(">");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(" ");

                }

                Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);

                Console.WriteLine(option.Name);
            }
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);

            Console.WriteLine(new string('*', margen));
        }
    }
}