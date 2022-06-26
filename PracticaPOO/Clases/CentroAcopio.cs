using Consoletabla;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO
{
    public class CentroAcopio
    {
        Tabla tabla;
        List<Producto> productos;

        public int Capacidad { get; private set; }

        public int TotalProductos => productos.Count;

        public int TotalBodegasVacias => Capacidad - productos.Count;

        /// <summary>
        /// Inicializa una instancia de un Centro de Acopio
        /// </summary>
        /// <param name="capacidad">Cantidad de espacios de almacenamiento en las bodegas inicialmente</param>
        public CentroAcopio(int capacidad)
        {
            Capacidad = capacidad;

            productos = new List<Producto>();

            tabla = new Tabla();
        }

        public bool GuardarProducto(Producto prod)
        {
            try
            {
                if (productos.Count >= Capacidad)
                {
                    throw new Exception("No hay capacidad suficiente para guardar el producto: " + prod);
                }

                productos.Add(prod);
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

        public void ImprimirReporte()
        {
            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            var productosPorTipo = productos
                                  .GroupBy(p => p.ToString())
                                  .Select(g => new { Nombre = g.Key, Cantidad = g.Count() })
                                  .OrderByDescending(p => p.Cantidad);

            int maxNombre = productosPorTipo.Max(n => n.Nombre.Length);

            tabla.EstablacerTitulos("Producto", "Cantidad");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (var prod in productosPorTipo)
            {
                tabla.AgregarFila(prod.Nombre, prod.Cantidad.ToString().PadLeft(10));
                tabla.EstaCentrado = true;
            }
            //tabla.Margin = (Console.WindowWidth - (maxNombre * 4)) / 2;
            Console.WriteLine(tabla.ToString());

            //Imprimir Existencias / Capacidad

            int cant = 0;
            foreach (var prod in productosPorTipo)
            {
                cant = cant + prod.Cantidad;
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            tabla.BorraFilas();
            tabla.EstablacerTitulos("Capacidad", "Existencias");
            tabla.AgregarFila(Capacidad.ToString().PadLeft(10), cant.ToString().PadLeft(10));
            tabla.EstaCentrado = true;
            Console.WriteLine(tabla.ToString());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");

            Console.ReadKey(true);
        }

        public Producto Retirar(Type tipoDeProducto)
        {
            foreach (var prod in productos)
            {
                if (prod.GetType() == tipoDeProducto)
                {
                    productos.Remove(prod);
                    return prod;
                }
            }

            return null;
        }

        //Este metodo lo consideramos por la indicación que la capacidad del centro de acopio puede crecer de 50 a más
        public void AgregarCapacidad(int cantidad)
        {
            Capacidad += cantidad;
        }
    }
}
