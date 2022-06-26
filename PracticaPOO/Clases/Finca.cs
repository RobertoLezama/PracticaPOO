using Consoletabla;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO.Clases
{
    public class Finca
    {
        Cooperativa cooperativa;
        List<Lote> lotes;
        Tabla tabla = new Tabla();

        public int Capacidad { get; private set; }

        public int TotalLotes => lotes.Count;

        public int TotalLotesDisponibles => Capacidad - lotes.Count;

        public Finca(Cooperativa coop, int capacidad)
        {
            //Guardar referencia a la cooperativa para futuro uso
            this.cooperativa = coop;

            //Establecer capacidad
            Capacidad = capacidad;

            //Configurar Lotes
            this.lotes = new List<Lote>();

            //Inicializar los lotes pre-existentes
            for (int i = 0; i < capacidad; i++)
            {
                lotes.Add(new Lote(coop));
            }
        }

        public bool Cultivar(Producto producto)
        {
            try
            {
                //Necesito determinar si hay lotes vacíos disponibles
                Lote loteVacío = null;

                foreach (var loteDisponible in this.lotes)
                {
                    if (loteDisponible.Producto == null)
                    {
                        loteVacío = loteDisponible;
                        break;
                    }
                }

                //Código equivalente más sencillo
                //var loteVacío2 = lotes.FirstOrDefault(l => l.Producto == null);

                if (loteVacío == null)
                {
                    throw new Exception("No hay capacidad suficiente para Cultivar el producto: " + producto);
                }

                loteVacío.Producir(producto);

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

            //Margen Superior
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            //Me trae el lote y el producto.
            tabla.BorraFilas();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            tabla.EstablacerTitulos("Lotes", "Producto");

            int totalVacios = 0;
            //Reporte de Lotes
            for (int i = 0; i < this.lotes.Count; i++)
            {
                tabla.EstaCentrado = true;

                string nombreProd;

                if (this.lotes[i].Producto != null)
                    nombreProd = lotes[i].Producto.ToString();
                else
                {
                    nombreProd = "<Vacío>";
                    totalVacios ++; 
                }

                //string nombreProd = this.lotes[i].Producto?.ToString() ?? "<Vacío>";

                tabla.AgregarFila((i + 1).ToString(), nombreProd.PadLeft(10));
            }

            tabla.EstaCentrado = true;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(tabla.ToString());

            //Imprimir Existencias / Capacidad
            tabla.BorraFilas();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int lotesProduciendo = TotalLotes - totalVacios;
            tabla.EstablacerTitulos("Capacidad", "Produciendo");
            tabla.AgregarFila(Capacidad.ToString().PadLeft(10), lotesProduciendo.ToString().PadLeft(10));
            tabla.EstaCentrado = true;

            Console.WriteLine(tabla.ToString());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");


            Console.ReadKey();
        }
    }
}
