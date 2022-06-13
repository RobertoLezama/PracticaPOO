using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO.UI
{
    internal class ConsoleMenu
    {
        private static int margen;
        private static bool isFirstTime;

        internal static void CreateMenu(List<ConsoleMenuOption> options, string Titulo = "")
        {
            Titulo = Titulo.Equals("") ? "Menu Principal" : Titulo;

            // Set the default index of the selected item to be the first
            int selectMenuIndex = 0;

            // Write the menu out
            ConsoleMenu.WriteMenu(options, options[selectMenuIndex], Titulo);

            // Store key info in here
            ConsoleKeyInfo keyinfo;

            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (selectMenuIndex + 1 < options.Count)
                    {
                        selectMenuIndex++;
                        ConsoleMenu.WriteMenu(options, options[selectMenuIndex], Titulo);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                        OpciónInválida(selectMenuIndex + 2);
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (selectMenuIndex - 1 >= 0)
                    {
                        selectMenuIndex--;
                        ConsoleMenu.WriteMenu(options, options[selectMenuIndex], Titulo);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                if (keyinfo.KeyChar > '0' && keyinfo.KeyChar <= '9')
                {
                    int dígito = int.Parse(keyinfo.KeyChar.ToString());

                    if (dígito <= options.Count)
                    {
                        options[dígito - 1].Selected.Invoke();
                        selectMenuIndex = dígito;
                    }
                    else
                        OpciónInválida(dígito);
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[selectMenuIndex].Selected.Invoke();
                    selectMenuIndex = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.Escape && keyinfo.Key != ConsoleKey.X);
        }

        private static void OpciónInválida(int opción)
        {
            Console.Write($"\r\tLa opción ({opción}) no existe\r");
        }

        internal static void WriteMenu(List<ConsoleMenuOption> options, ConsoleMenuOption selectedOption, string Titulo)
        {
            if (!isFirstTime)
            {
                int lenght = options.Max(o => o.Name.Length);
                var template = "*  {0," + lenght + "}  *";
                margen = lenght + 6;

                for (int i = 0; i < options.Count; i++)
                {
                    options[i].Name = options[i].Name.PadRight(lenght, ' ');
                    options[i].Name = string.Format(template, options[i].Name);
                }
                isFirstTime = true;
            }

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Console.WriteLine(new string('*', margen));
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Console.WriteLine($"*      {Titulo}      *");
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