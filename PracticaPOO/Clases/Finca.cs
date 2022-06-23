using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTable;

namespace PracticaPOO.Clases
{
    public class Finca
    {
        static Table table = new Table();
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
            if (lotes.Count >= Capacidad)
            {
                throw new Exception("No hay capacidad suficiente para Cultivar el producto: " + producto);
            }

            lotes.Add(new Lote(cooperativa, producto));
            return true;
        }

        
        public void ImprimirLotes()
        {
            

            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            //Me trae el lote y el producto.
            table.ClearRows();
            table.SetHeaders("Lotes", "Producto");
            for (int i = 0; i < this.lotes.Count; i++)
            {
                //Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                table.AddRow((i + 1).ToString(), this.lotes[i].Producto.ToString());
            }
            Console.WriteLine(table.ToString());

            //Imprimir Existencias / Capacidad
            table.ClearRows();
            int cant = this.lotes.Count;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            table.SetHeaders("Capacidad", "Produciendo");
            table.AddRow(Capacidad.ToString(), cant.ToString());

            Console.WriteLine(table.ToString());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");


            Console.ReadKey();
        }
    }
}
