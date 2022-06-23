﻿using PracticaPOO.Clases;
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
            AlinearVentanaConsola();
            InicializarCooperativa();

            // Create options that you want your menu to have
            opcionesMenu = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Administrar Granja", AdministrarGranja),
                new ConsoleMenuOption("Animales", AnimalesSubMenu),
                new ConsoleMenuOption("Inventario", RptInventario),
                new ConsoleMenuOption("Cultivos", CultivosSubMenu),
                new ConsoleMenuOption("Acerca De...", MostrarAcercaDe),
                new ConsoleMenuOption("Salir", () => Environment.Exit(0))
            };

            try
            {
                ConsoleMenu.CreateMenu(opcionesMenu);
            }
            catch (ErrorCooperativa ex)
            {
                MostrarMensaje("Se produjo un error de Cooperativa: " + ex.Message);
            }

            MostrarMensaje("Chao...");
        }

        private static void AlinearVentanaConsola()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 5);
            Console.SetWindowPosition(0, 0);
        }

        private static void AdministrarGranja()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Opcion 1", AdministrarOpcion1),
                new ConsoleMenuOption("Opción 2", () =>  MostrarMensaje("\r\tEsta es la opcion 2"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar las opicones del menú", true);
        }

        private static void AnimalesSubMenu()
        {
            var menuAnimales = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Vacas", AccionesVacas),
                new ConsoleMenuOption("Gallinas", AccionesGallinas),
                new ConsoleMenuOption("Cerdos", AccionesCerdos),
            };
            ConsoleMenu.CreateMenu(menuAnimales, "Animales", true);
        }

        private static void CultivosSubMenu()
        {
            var menuCultivos1 = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Cultivar", CultivosMenu),
                new ConsoleMenuOption("Imprimir Cultivos", ImprimirCultivos),
            };

            ConsoleMenu.CreateMenu(menuCultivos1, "Cultivos", true);
        }

        private static void CultivosMenu()
        {
            var menuProducir = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Granos", () => SubMenuCultivos(typeof(Grano), typeof(Enums.Grano), "Granos")),
                new ConsoleMenuOption("Frutas", () => SubMenuCultivos(typeof(Fruta), typeof(Enums.Fruta), "Fruta")),
                new ConsoleMenuOption("Legumbres",() => SubMenuCultivos(typeof(Legumbre), typeof(Enums.Legumbre), "Legumbre")),
                new ConsoleMenuOption("Semillas",() => SubMenuCultivos(typeof(Semilla), typeof(Enums.Semilla), "Semilla")),
            };

            ConsoleMenu.CreateMenu(menuProducir, "Cultivar", true);
        }

        private static void SubMenuCultivos(Type vegetal, Type tiposDeVegetal, string titulo)
        {
            var menuCultivos2 = new List<ConsoleMenuOption>();

            foreach (var tipoDeVegetal in Enum.GetValues(tiposDeVegetal))
            {
                menuCultivos2.Add(new ConsoleMenuOption($"{tipoDeVegetal}", () => Cultivando((ProdVegetal)Activator.CreateInstance(vegetal, tipoDeVegetal))));
            }

            ConsoleMenu.CreateMenu(menuCultivos2, titulo, true);
        }

        private static void Cultivando(ProdVegetal vegetal)
        {
            if (coop.Cultivar(vegetal))
                MostrarMensaje($"Vegetal: { vegetal.ToString() }, cultivado con éxito.");
        }

        private static void RptInventario()
        {
            coop.ImprimirInventario();
        }

        private static void ImprimirCultivos()
        {
            coop.RptImprimirCultivos();
        }

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
                new ConsoleMenuOption("Opcion 1.1", () => MostrarMensaje("\r\tEsta es la opcion 1.1")),
                new ConsoleMenuOption("Opción 1.2", () => MostrarMensaje("\r\tEsta es la opcion 1.2"))
            };
            ConsoleMenu.CreateMenu(menuAdministrar, "Administrar Sub Opción 1", true);
        }

        private static void AccionesVacas()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Leche", () => MostrarMensaje("\r\tMOOOOOOOO")),
                new ConsoleMenuOption("Queso", () => MostrarMensaje("\r\tMAS MOOOOOOOOOO")),
                new ConsoleMenuOption("Carne", () => MostrarMensaje("\r\tOTRA VEZ MOOOOO"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Vacas", true);
        }

        private static void AccionesGallinas()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Pollo", () => MostrarMensaje("\r\tEsta es la opcion de pollo")),
                new ConsoleMenuOption("Huevos", () => MostrarMensaje("\r\tEsta es la opcion de huevo"))
            };

            ConsoleMenu.CreateMenu(menuAdministrar, "Gallinas", true);
        }

        private static void AccionesCerdos()
        {
            var menuAdministrar = new List<ConsoleMenuOption>
            {
                new ConsoleMenuOption("Tocino", () => throw new ErrorCooperativa ("\r\tNo me maten")),
                new ConsoleMenuOption("Chicharron", () => MostrarMensaje("\r\tHoy se come Chifrijo"))
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
            coop.Abonar(5000);

            coop.SimularExistenciasDeProductos();
        }
    }
}