﻿using PracticaPOO.Clases;
using PracticaPOO.UI;
using System;
using System.Collections.Generic;
using PracticaPOO.Enums;

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
                new ConsoleMenuOption("1 - Administrar Granja", AdministrarGranja),
                new ConsoleMenuOption("2 - Animales", AnimalesSubMenu),
                new ConsoleMenuOption("3 - Inventario", RptInventario),
                new ConsoleMenuOption("4 - Cultivos", CultivosSubMenu),
                new ConsoleMenuOption("5 - Acerca De...", MostrarAcercaDe),
                new ConsoleMenuOption("6 - Salir", () => Environment.Exit(0))
            };

            try
            {
                ConsoleMenu.CreateMenu(opcionesMenu);
            }
            catch (ArgumentNullException e)
            {
                MostrarMensaje("Se produjo un error de Nulos");
            }
            catch (DivideByZeroException e2)
            {
                MostrarMensaje("Se produjo un error de División por Cero");
            }
            catch (ErrorCooperativa e3)
            {
                MostrarMensaje("Se produjo un error de Cooperativa");
            }

            MostrarMensaje("Chao...");
        }

        private static void AdministrarGranja()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Opcion 1", AdministrarOpcion1),
                new ConsoleMenuOption("2 - Opción 2", () =>  MostrarMensaje("\r\tEsta es la opcion 2"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar las opicones del menú", true);
        }

        private static void AnimalesSubMenu()
        {
            var menuAnimales = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Vacas", AccionesVacas),
                new ConsoleMenuOption("2 - Gallinas", AccionesGallinas),
                new ConsoleMenuOption("3 - Cerdos", AccionesCerdos),
            };
            ConsoleMenu.CreateMenu(menuAnimales, "Animales", true);
        }

        private static void CultivosSubMenu()
        {
            var menuCultivos = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Producir", CultivosMenu),
                new ConsoleMenuOption("2 - Imprimir Cultivos", RptInventario),
            };

            ConsoleMenu.CreateMenu(menuCultivos, "Cultivos", true);
        }

        private static void CultivosMenu()
        {
            var menuProducir = new List<ConsoleMenuOption>


            int index = 1;

            for(int i = 0; i < menuProducir.Count; i++)
            {
                index++;
            }

            {
                new ConsoleMenuOption($"{index} - Granos", () => SubMenuCultivos(Enum.GetValues(typeof(Enums.Grano)), "Granos")),
                new ConsoleMenuOption($"{index} - Frutas", () => SubMenuCultivos(Enum.GetValues(typeof(Enums.Fruta)), "Granos")),
                new ConsoleMenuOption($"{index} - Legumbres",() => SubMenuCultivos(Enum.GetValues(typeof(Enums.Legumbre)), "Granos")),
                new ConsoleMenuOption($"{index} - Semillas",() => SubMenuCultivos(Enum.GetValues(typeof(Enums.Semilla)), "Granos")),
            };

            ConsoleMenu.CreateMenu(menuProducir, "Producir", true);
        }

        private static void SubMenuCultivos(Array cultivos, string titulo)
        {
            var menuCultivos = new List<ConsoleMenuOption>();
            int num = 1;
            foreach (var item in cultivos)
            {
                menuCultivos.Add(new ConsoleMenuOption($"{num} - {item}", () => MostrarMensaje($"Produciendo {item}")));
                num++;
            }

            ConsoleMenu.CreateMenu(menuCultivos, titulo, true);
        }

        private static void RptInventario()
        {
            coop.ImprimirInventario();
        }

        //private static void TrabSubMenu()
        //{
        //    var menuTrabajadores = new List<ConsoleMenuOption>
        //    {
        //        new ConsoleMenuOption("1 - Nombre y cargo", AdministrarOpcion1),
        //        new ConsoleMenuOption("2 - ", () =>  MostrarMensaje("\r\tEsta es la opcion 2"))
        //    };
        //    ConsoleMenu.CreateMenu(menuTrabajadores, "Trabajadores", true);
        //}

        //private static void ProdSubMenu()
        //{
        //    var menuProductos = new List<ConsoleMenuOption>
        //    {
        //        new ConsoleMenuOption("1 - Opcion 1", AdministrarOpcion1),
        //        new ConsoleMenuOption("2 - Opción 2", () =>  MostrarMensaje("\r\tEsta es la opcion 2"))
        //    };
        //    ConsoleMenu.CreateMenu(menuProductos, "Productos", true);
        //}

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");
            Console.ReadKey(true);
        }

        private static void AdministrarOpcion1()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Opcion 1.1", () => MostrarMensaje("\r\tEsta es la opcion 1.1")),
                new ConsoleMenuOption("2 - Opción 1.2", () => MostrarMensaje("\r\tEsta es la opcion 1.2"))
            };
            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar Sub Opción 1", true);
        }

        private static void AccionesVacas()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Leche", () => MostrarMensaje("\r\tMOOOOOOOO")),
                new ConsoleMenuOption("2 - Queso", () => MostrarMensaje("\r\tMAS MOOOOOOOOOO")),
                new ConsoleMenuOption("3 - Carne", () => MostrarMensaje("\r\tOTRA VEZ MOOOOO"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Vacas", true);
        }

        private static void AccionesGallinas()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Pollo", () => MostrarMensaje("\r\tEsta es la opcion de pollo")),
                new ConsoleMenuOption("2 - Huevos", () => MostrarMensaje("\r\tEsta es la opcion de huevo"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Gallinas", true);
        }

        private static void AccionesCerdos()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("1 - Tocino", () => throw new ErrorCooperativa ("\r\tNo me maten")),
                new ConsoleMenuOption("2 - Chicharron", () => MostrarMensaje("\r\tHoy se come Chifrijo"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Cerdos", true);
        }

        private static void MostrarAcercaDe()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Clear();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("\t\tNombre: Menu de la cooperativa.");
            Console.WriteLine("\t\tVersión: 2.0.");
            Console.WriteLine("\t\tProgramadores: Heiner Morales, Roberto Lezama y Leidy Monge.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\tPresione cualquier tecla para continuar . . .");

            Console.ReadKey(true);
        }

        private static void InicializarCooperativa()
        {
            //Hacer depósito Inicial
            coop.Abonar(500);

            coop.SimularExistenciasDeProductos();
        }
    }
}