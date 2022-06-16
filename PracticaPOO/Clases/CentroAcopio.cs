using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var productosPorTipo = productos.GroupBy(p => p.ToString());
            int tamProdMax = productosPorTipo.Max(p => p.Key.Length);
            tamProdMax = tamProdMax > 8 ? tamProdMax : 8;
            var template = "\r║  {0," + tamProdMax + "}   ║  {1, 8}   ║";
            //Console.WriteLine("\r"+new string('═', tamProdMax+21));
            string esquinaSuper = "\r" +new string('═', tamProdMax + 21).Substring(0, 1).Replace('═', '╔') + new string('═', tamProdMax + 21).Substring(1, tamProdMax + 19) + new string('═', tamProdMax + 21).Substring(tamProdMax + 20).Replace('═', '╗');
            Console.WriteLine(esquinaSuper);
            Console.WriteLine(string.Format(template, "Producto".PadRight(tamProdMax, ' '), "Cantidad".PadRight(tamProdMax, ' ')));
            string esquinaMedio = new string('═', tamProdMax + 21).Substring(0, 1).Replace('═', '╠') + new string('═', tamProdMax + 21).Substring(1, tamProdMax + 19) + new string('═', tamProdMax + 21).Substring(tamProdMax + 20).Replace('═', '╣');
            Console.WriteLine(esquinaMedio);
            foreach (var prod in productosPorTipo)
            {
                Console.WriteLine(string.Format(template, prod.Key.PadRight(tamProdMax, ' '), prod.Count()));
            }
            string esquina = new string('═', tamProdMax + 21).Substring(0, 1).Replace('═', '╚') + new string('═', tamProdMax + 21).Substring(1, tamProdMax + 19) + new string('═', tamProdMax + 21).Substring(tamProdMax + 20).Replace('═', '╝');
            Console.WriteLine(esquina);
            //Imprimir Existencias / Capacidad

            Console.ReadLine();
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
