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
            Console.Clear();

            Console.SetCursorPosition((Console.WindowWidth - 12) / 2, Console.CursorTop);

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop);
            Console.WriteLine("********************");
            Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop);
            Console.WriteLine("*  Menu principal  *");
            Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop);
            Console.WriteLine("********************");



            foreach (ConsoleMenuOption option in options)
            {
                if (option == selectedOption)
                {

                    //Console.Write(">");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(" ");

                }

                Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop);
                
                Console.WriteLine(option.Name);
            }
            Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop);

            Console.WriteLine("********************");
        }
    }
}