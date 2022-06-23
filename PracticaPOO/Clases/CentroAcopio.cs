using System;
using System.Collections.Generic;
using System.Linq;
using PracticaPOO.Clases;
using ConsoleTable;

namespace PracticaPOO
{
    public class CentroAcopio
    {
        static Table table = new Table();
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
        }

        public bool GuardarProducto(Producto prod)
        {
            if (productos.Count >= Capacidad)
            {
                throw new Exception("No hay capacidad suficiente para guardar el producto: " + prod);
            }

            productos.Add(prod);
            return true;
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
            
         

            table.SetHeaders("Producto", "Cantidad");
            foreach(var prod in productosPorTipo)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan; 
                table.AddRow(prod.Nombre, prod.Cantidad.ToString());
            }

            Console.WriteLine(table.ToString());

            //Imprimir Existencias / Capacidad
           
            int cant = 0;
            foreach(var prod in productosPorTipo)
            {
                cant = cant + prod.Cantidad;
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            table.SetHeaders("Capacidad", "Existencias");
            table.AddRow(Capacidad.ToString(), cant.ToString());

            Console.WriteLine(table.ToString());

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
