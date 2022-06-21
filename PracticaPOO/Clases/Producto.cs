using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOO
{
    public abstract class Producto
    {
		public string Nombre { get; set; }
		public decimal Precio { get; set; }

		public abstract int Tiempo { get; set; }

		public Producto(string nombre, decimal precio, int tiempo)
		{
			Nombre = nombre;
			Precio = precio;
			Tiempo = tiempo;
		}

        public override string ToString()
        {
			return this.Nombre;
        }
    }
}
