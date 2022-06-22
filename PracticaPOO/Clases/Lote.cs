namespace PracticaPOO
{
    public class Lote : IProductor
    {
		Cooperativa cooperativa;

		 public string NombreLote;
		public Producto producto { get; set; }

        public Lote(string nombre, Producto producto)
		{
			NombreLote = nombre;
			this.producto = producto;
		}

		public void Producir(Producto producto)
		{
			cooperativa.Gastar(producto.Precio);

								
		}
	}
}
