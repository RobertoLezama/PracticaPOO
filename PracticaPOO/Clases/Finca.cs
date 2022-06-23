using ConsoleTable;
using System;
using System.Collections.Generic;

namespace PracticaPOO.Clases
{
    public class Finca
    {
        Table tabla = new Table();
        List<Lote> lotes;

        Cooperativa cooperativa;

        public int Capacidad { get; private set; }

        public int TotalLotes => lotes.Count;

        public int TotalLotesDisponibles => Capacidad - lotes.Count;

        public Finca(Cooperativa coop, int capacidad)
        {
            this.cooperativa = coop;
            this.lotes = new List<Lote>();

            Capacidad = capacidad;
        }

        public bool Cultivar(Producto producto)
        {
            try
            {
                if (lotes.Count >= Capacidad)
                {
                    throw new Exception("No hay capacidad suficiente para Cultivar el producto: " + producto);
                }

                lotes.Add(new Lote(cooperativa, producto));
                return true;

            }
            catch (Exception ex)
            {
                MostrarMensaje("Se produjo un error: " + ex.Message);
                Console.ReadKey();
                return false; 
            }
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");
            Console.ReadKey(true);
        }


        public void ImprimirLotes()
        {
            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            //Me trae el lote y el producto.
            tabla.ClearRows();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            tabla.SetHeaders("Lotes", "Producto");

            for (int i = 0; i < this.lotes.Count; i++)
            {
                tabla.AddRow((i + 1).ToString(), this.lotes[i].Producto.ToString());
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(tabla.ToString());

            //Imprimir Existencias / Capacidad
            tabla.ClearRows();
            int cant = this.lotes.Count;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            tabla.SetHeaders("Capacidad", "Produciendo");
            tabla.AddRow(Capacidad.ToString(), cant.ToString());

            Console.WriteLine(tabla.ToString());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");


            Console.ReadKey();
        }
    }
}
