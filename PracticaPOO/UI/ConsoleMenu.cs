using System;
using System.Collections.Generic;

namespace PracticaPOO.UI
{
    internal class ConsoleMenu
    {

        internal static void CreateMenu(List<ConsoleMenuOption> options)
        {
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
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        ConsoleMenu.WriteMenu(options, options[index]);
                    }
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }

        internal static void WriteMenu(List<ConsoleMenuOption> options, ConsoleMenuOption selectedOption)
        {
            Console.Clear();

            foreach (ConsoleMenuOption option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }
}