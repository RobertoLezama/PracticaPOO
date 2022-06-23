using ConsoleTable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO
{
    public class CentroAcopio
    {
        Table tabla;
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

            tabla = new Table();
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
                Console.WriteLine(ex);
                Console.ReadKey();
                return false;
            }
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



            tabla.SetHeaders("Producto", "Cantidad");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (var prod in productosPorTipo)
            {
                tabla.AddRow(prod.Nombre, prod.Cantidad.ToString());
            }

            Console.WriteLine(tabla.ToString());

            //Imprimir Existencias / Capacidad

            int cant = 0;
            foreach (var prod in productosPorTipo)
            {
                cant = cant + prod.Cantidad;
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            tabla.ClearRows();
            tabla.SetHeaders("Capacidad", "Existencias");
            tabla.AddRow(Capacidad.ToString(), cant.ToString());

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
