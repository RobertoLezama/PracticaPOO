using PracticaPOO.UI;
using System;
using System.Collections.Generic;

namespace PracticaPOO
{
    public class Programa
    {
        static Cooperativa coop = new Cooperativa();
        static List<ConsoleMenuOption> opcionesMenu;

        static void Main()
        {
            InicializarCooperativa();

            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Opción 1", () => Console.WriteLine("Hola")),
                new ConsoleMenuOption("Opción 2", () =>  Console.WriteLine("Mundo")),
                new ConsoleMenuOption("Opción 3", HacerAlgo),
                new ConsoleMenuOption("Salir", () => Environment.Exit(0)),
            };

            ConsoleMenu.CreateMenu(opcionesMenu);
        }

        private static void HacerAlgo()
        {
            Console.WriteLine("Adios");
        }

        private static void InicializarCooperativa()
        {
            //Hacer depósito Inicial
            coop.Abonar(500);
        }
    }
}