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

            List<string> Trabajadores = new List<string>
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
                //new ConsoleMenuOption("2 - Animales", () =>  SubMenu(Animales, opcionesMenu,"Animales")),
                //new ConsoleMenuOption("3 - Trabajadores", () => SubMenu(Trabajadores, opcionesMenu, "Trabajadores")),
                //new ConsoleMenuOption("4 - Productos", () => SubMenu(Productos, opcionesMenu, "Productos")),
                new ConsoleMenuOption("5 - Acerca De...", MostrarAcercaDe),
                new ConsoleMenuOption("6 - Salir", () => Environment.Exit(0))
            };

            ConsoleMenu.CreateMenu(opcionesMenu);
        }

        private static void AdministrarGranja()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Opcion 1", AdministrarOpcion1),
                new ConsoleMenuOption("2 - Opción 2", () =>  MostrarMensaje("\r\tEsta es la opcion 2"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar");
        }

        private static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("> Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        private static void AdministrarOpcion1()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Opcion 1.1", () => MostrarMensaje("\r\tEsta es la opcion 1.1")),
                new ConsoleMenuOption("2 - Opción 1.2", () => MostrarMensaje("\r\tEsta es la opcion 1.2"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar Sub Opción 1");
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