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
            
            InicializarCooperativa();
            
            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("*   1 - Opción 1 Opción 1 Opción 1 Opción 1 Opción 1   *", () => Console.WriteLine("\r\tHola")),
                new ConsoleMenuOption("*   2 - Opción 2   *", () =>  Console.WriteLine("\r\tMundo")),
                new ConsoleMenuOption("*   3 - Opción 3   *", HacerAlgo),
                new ConsoleMenuOption("*   4 - Salir      *", () => Environment.Exit(0)),
            };
                        
            ConsoleMenu.CreateMenu(opcionesMenu);
        }


        private static void HacerAlgo()
        {
            Console.WriteLine("\r\tAdios");
            
        }

        private static void InicializarCooperativa()
        {
            //Hacer depósito Inicial
            coop.Abonar(500);
        }
    }
}