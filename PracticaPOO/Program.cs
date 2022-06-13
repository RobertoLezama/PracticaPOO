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

            List<string> Animales = new List<string>
            {
                "Vacas",
                "Cerdos",
                "Gallinas"
            };

            List<string> trabajadores = new List<string>
            {
                "Heiner",
                "Roberto",
                "Leidy"
            };

            List<string> Productos = new List<string>
            {
                "Leche",
                "Huevos",
                "Carne",
                "Vegetales"
            };


            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Administrar Granja", AdministrarGranja),
                new ConsoleMenuOption("2 - Animales", () =>  SubMenu(Animales, opcionesMenu)),
                new ConsoleMenuOption("3 - Acerca De...", MostrarAcercaDe),
                new ConsoleMenuOption("4 - Trabajadores", () => SubMenu(trabajadores, opcionesMenu)),
                new ConsoleMenuOption("5 - Productos", () => SubMenu(Productos, opcionesMenu)),
                new ConsoleMenuOption("6 -Salir", () => Environment.Exit(0))
            };

            ConsoleMenu.CreateMenu(opcionesMenu);
        }

        private static void AdministrarGranja()
        {
            List<ConsoleMenuOption> misOpciones = new List<ConsoleMenuOption>();

            List<string> optMenu = new List<string>
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

        private static void SubMenu(List<string> items,List<ConsoleMenuOption> MenuAnterior)
        {
            List<ConsoleMenuOption> subMenuOpt = new List<ConsoleMenuOption>();
            int index = 1;
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
                ConsoleMenu.CreateMenu(MenuAnterior);
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