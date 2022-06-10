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
            
            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("*   1 - Opción 1   *", () => Console.WriteLine("\r\tHola")),
                new ConsoleMenuOption("*   2 - Opción 2   *", () =>  Console.WriteLine("\r\tMundo")),
                new ConsoleMenuOption("*   3 - Opción 3   *", HacerAlgo),
                new ConsoleMenuOption("*   4 - Salir      *", () => Environment.Exit(0)),
            };
                        
            ConsoleMenu.CreateMenu(opcionesMenu);
        }


        private static void HacerAlgo()
        {

            Console.ForegroundColor = ConsoleColor.White; 

            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("");
            }
           

            Console.WriteLine("\t\tNombre: Menu de la cooperativa.");
            Console.WriteLine("\t\tVersión: 2.0.");
            Console.WriteLine("\t\tProgramadores: Heiner Morales, Roberto Lezama y Leidy Monge.");
            Console.WriteLine("");
            Console.WriteLine("\t\tPresione la tecla Escape o x para volver al Menu Principal");

            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if(keyinfo.Key == ConsoleKey.Escape || keyinfo.Key == ConsoleKey.X)
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