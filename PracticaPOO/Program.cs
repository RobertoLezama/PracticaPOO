using PracticaPOO.UI;
using System;
using System.Collections.Generic;

namespace PracticaPOO
{
    public class Programa
    {
        static Cooperativa coop = new Cooperativa();
        static List<ConsoleMenuOption> opcionesMenu;

        static void Main(string[] args)
        {
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            InicializarCooperativa();

            var options2 = new List<string>
            {
                "Opt sub menu1",
                "Opt sub menu2",
                "Opt sub menu3"
            };

            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Administrar Granja", AdministrarGranja),
                new ConsoleMenuOption("2 - Animales", () =>  SubMenu(options2, opcionesMenu)),
                new ConsoleMenuOption("3 - Acerca De...", MostrarAcercaDe),
                new ConsoleMenuOption("4 - Salir", () => Environment.Exit(0)),
                new ConsoleMenuOption("5 - Opción 3", () =>  Console.WriteLine("\r\tHaciendo algo más")),
                new ConsoleMenuOption("6 - Opción 4", () =>  Console.WriteLine("\r\tHaciendo aún algo más"))
            };

            ConsoleMenu.CreateMenu(opcionesMenu);
        }

        private static void AdministrarGranja()
        {
            List<ConsoleMenuOption> misOpciones = new List<ConsoleMenuOption>();

            var optMenu = new List<string>
            {
                "Opt sub menu1",
                "Opt sub menu2",
                "Opt sub menu3",
                
            };

            misOpciones = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Opcion 1",() => SubMenu(optMenu, misOpciones)),
                new ConsoleMenuOption("2 - Opción 2", () =>  Console.WriteLine("\r\tEsta es la opcion 2"))
            };

            ConsoleMenu.CreateMenu(misOpciones);

            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape || keyinfo.Key == ConsoleKey.X)
            {
                ConsoleMenu.CreateMenu(opcionesMenu);
            }
        }

        private static void SubMenu(List<string> items,List<ConsoleMenuOption> options)
        {
            var subMenuOpt = new List<ConsoleMenuOption>();
            var index = 1;
            items.ForEach(opt =>
            {
                subMenuOpt.Add(new ConsoleMenuOption($"{index} {opt}", () => Console.WriteLine($"\r\tNombre: {opt}")));
                index++;
            });
            ConsoleMenu.CreateMenu(subMenuOpt);

            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape || keyinfo.Key == ConsoleKey.X)
            {
                ConsoleMenu.CreateMenu(options);
            }
        }


        private static void MostrarAcercaDe()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("\t\tNombre: Menu de la cooperativa.");
            Console.WriteLine("\t\tVersión: 2.0.");
            Console.WriteLine("\t\tProgramadores: Heiner Morales, Roberto Lezama y Leidy Monge.");
            Console.WriteLine();
            Console.WriteLine("\t\tPresione la tecla Escape o x para volver al Menu Principal");

            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.Escape || keyinfo.Key == ConsoleKey.X)
            {
                ConsoleMenu.CreateMenu(opcionesMenu);
            }
        }

        private static void InicializarCooperativa()
        {
            //Hacer depósito Inicial
            coop.Abonar(500);
        }
    }
}