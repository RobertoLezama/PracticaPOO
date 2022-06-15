using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO.UI
{
    internal class ConsoleMenu
    {
        private static int margen;
        private static bool isFirstTime;
        private static bool subMenu;
        private static string template;
        private static int lenght;

        internal static void CreateMenu(List<ConsoleMenuOption> options, string Titulo = "", bool isSubmenu = false)
        {
            Titulo = string.IsNullOrEmpty(Titulo) ? "Menu Principal" : Titulo;
            //Esto se crea para que cuando entramos a un submenu se alinie y se le dibujen los caracteres del marco dinámicamente
            subMenu = isFirstTime && isSubmenu ? true : false;

            // Set the default index of the selected item to be the first
            int selectMenuIndex = 0;

            // Store key info in here
            ConsoleKeyInfo keyinfo;

            do
            {
                // Write the menu out
               ConsoleMenu.WriteMenu(options, options[selectMenuIndex], Titulo);

                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (selectMenuIndex + 1 < options.Count)
                    {
                        selectMenuIndex++;
                        ConsoleMenu.WriteMenu(options, options[selectMenuIndex], Titulo);
                        //Console.BackgroundColor = ConsoleColor.Black;
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
                        //Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                if (keyinfo.KeyChar > '0' && keyinfo.KeyChar <= '9')
                {
                    int dígito = int.Parse(keyinfo.KeyChar.ToString());

                    if (dígito <= options.Count)
                    {
                        options[dígito - 1].Selected.Invoke();
                        selectMenuIndex = 0;
                    }
                    else
                    {
                        OpciónInválida(dígito);
                    }
                        
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[selectMenuIndex].Selected.Invoke();
                    selectMenuIndex = 0;
                }
                //Esta validación es para cuando salimos con ESC o X se le dibuje de nuevo el marco y quede alineado
                if (isFirstTime)
                {
                    isFirstTime = false;
                    subMenu = true;
                };
            }
            while (keyinfo.Key != ConsoleKey.Escape && keyinfo.Key != ConsoleKey.X);

            
        }

        private static void OpciónInválida(int opción)
        {
            Console.WriteLine($"\r\tLa opción ({opción}) no existe");
            //Añadimos estas lineas porque fue la forma en la que se logró imprimir la opción invalida, sin estas no se imprime.
            Console.WriteLine("> Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        internal static void WriteMenu(List<ConsoleMenuOption> options, ConsoleMenuOption selectedOption, string Titulo)
        {
            foreach (ConsoleMenuOption option in options)
            //Se retiran los caracteres especiales y con el trim se le quietan los espacios para que se vuelvan a crear.
            {
                if (option.Name.Contains('║'))
                {
                    option.Name = option.Name.Replace('║', ' ').Trim();
                } 
            }

            lenght = options.Max(o => o.Name.Length);
            lenght = lenght > Titulo.Length ? lenght : Titulo.Length;
            template = "║  {0," + lenght + "}  ║";
            margen = lenght + 6;

            if (!isFirstTime || subMenu)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    options[i].Name = options[i].Name.PadRight(lenght, ' ');
                    options[i].Name = string.Format(template, options[i].Name);
                }
                isFirstTime = true;
                subMenu = false;
            }

            Console.Clear();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            string esquinaSuper = new string('═', margen).Substring(0, 1).Replace('═', '╔') + new string('═', margen).Substring(1, margen - 2) + new string('═', margen).Substring(margen - 1).Replace('═', '╗');
            Console.WriteLine(esquinaSuper);
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            Titulo = Titulo.PadRight(lenght, ' ').PadLeft(lenght, ' ');
            Console.WriteLine(string.Format(template,Titulo));
            Console.SetCursorPosition((Console.WindowWidth - margen) / 2, Console.CursorTop);
            string esquinaMedio = new string('═', margen).Substring(0, 1).Replace('═', '╠') + new string('═', margen).Substring(1, margen - 2) + new string('═', margen).Substring(margen - 1).Replace('═', '╣');
            Console.WriteLine(esquinaMedio);

            foreach (ConsoleMenuOption option in options)
            {
                if (option == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.Write(">");
                   

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

            string esquina = new string('═', margen).Substring(0,1).Replace('═', '╚') + new string('═', margen).Substring(1, margen - 2) + new string('═', margen).Substring(margen - 1).Replace('═', '╝');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(esquina);

        }
    }
}