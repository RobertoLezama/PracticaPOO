using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO
{
    public class CentroAcopio
    {
        
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

            var productosPorTipo = productos
                                  .GroupBy(p => p.ToString())
                                  .Select(g => new { Nombre = g.Key, Cantidad = g.Count() });

            int tamProdMax = productosPorTipo.Max(p => p.Nombre.Length);
            int tamCantMax = productosPorTipo.Max(c => c.Cantidad.ToString().Length);
            tamProdMax = tamProdMax > 8 ? tamProdMax : 8;
            tamCantMax = tamCantMax > 8 ? tamCantMax : 8;

            string template = "\r│  {0," + tamProdMax + "}   │  {1," + tamCantMax + "}   │";
            
            string esquinaSuper = "\r" +new string('─', tamProdMax + 21).Substring(0, 1).Replace('─', '┌') + 
                new string('─', tamProdMax + 21).Substring(1, tamProdMax + 5) 
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, 1).Replace('─', '┬') 
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, tamCantMax + 5)
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 20).Replace('─', '┐');
            Console.WriteLine(esquinaSuper);

            Console.WriteLine(string.Format(template, "Producto".PadRight(tamProdMax, ' '), "Cantidad".PadRight(tamCantMax, ' ')));
            string esquinaMedio = new string('─', tamProdMax + 21).Substring(0, 1).Replace('─', '├') 
                + new string('─', tamProdMax + 21).Substring(1, tamProdMax + 5)
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, 1).Replace('─', '┼')
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, tamCantMax + 5)
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 20).Replace('─', '┤');
            Console.WriteLine(esquinaMedio);

            foreach (var prod in productosPorTipo)
            {
                Console.WriteLine(string.Format(template, prod.Nombre.PadRight(tamProdMax, ' '), prod.Cantidad));
               
            }

            string esquina = new string('─', tamProdMax + 21).Substring(0, 1).Replace('─', '└')
                + new string('─', tamProdMax + 21).Substring(1, tamProdMax + 5)
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, 1).Replace('─', '┴')
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 6, tamCantMax + 5)
                + new string('─', tamProdMax + 21).Substring(tamProdMax + 20).Replace('─', '┘');
            Console.WriteLine(esquina);

            //Imprimir Existencias / Capacidad
           
            int cant = 0;
            foreach(var prod in productosPorTipo)
            {
                cant = cant + prod.Cantidad;
            }
            
            string cuadro = "│  {0," + 11 + "}   │  {1," + 9 + "}   │";
            string esquinaCua =  new string('─', 33).Substring(0, 1).Replace('─', '┌') +
                new string('─',  33).Substring(1, 16)
                + new string('─', 33).Substring(17, 1).Replace('─', '┬')
                + new string('─', 33).Substring(17, 14)
                + new string('─', 33).Substring(32).Replace('─', '┐');
            Console.WriteLine(esquinaCua);
            Console.WriteLine(string.Format(cuadro, "Existencias", "Cantidad"));

            string esquinaMed = new string('─', 33).Substring(0, 1).Replace('─', '├')
               + new string('─', 33).Substring(1, 16)
               + new string('─', 33).Substring(17 , 1).Replace('─', '┼')
               + new string('─', 33).Substring(17, 14)
               + new string('─', 33).Substring(32).Replace('─', '┤');
            Console.WriteLine(esquinaMed);

            
            Console.WriteLine(string.Format(cuadro, Capacidad, cant));
            string esquinaAb = new string('─', 33).Substring(0, 1).Replace('─', '└')
                + new string('─',33).Substring(1, 16)
                + new string('─', 33).Substring(17, 1).Replace('─', '┴')
                + new string('─', 33).Substring(17, 14)
                + new string('─', 33).Substring(32).Replace('─', '┘');
            Console.WriteLine(esquinaAb);

           
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
