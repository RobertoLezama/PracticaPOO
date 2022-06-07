﻿namespace PracticaPOO.Clases
{
    public class Corral : Granja, IProductor
	{

		Cooperativa cooperativa;
		private Producto producto;

		public Corral(string nombre, int cantidad, Cooperativa coop) : base(nombre, Enums.TipoProducto.Leche, cantidad)
		{
			cooperativa = coop;
		}


		public void Producir(Producto producto)
		{
			this.producto = producto;
			cooperativa.Gastar(producto.Precio);
		}

	}
}
