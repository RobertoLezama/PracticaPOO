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

        /*
        public int CantProdVegetal => productos.Count(p => p is ProdVegetal);
        public int CantProdAnimal { get; set; }
        */

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
