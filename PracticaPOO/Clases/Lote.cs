namespace PracticaPOO
{
    public class Lote : IProductor
    {
		Cooperativa cooperativa;

		Producto producto { get; set; }

        public Lote(Cooperativa coop)
		{
			cooperativa = coop;
		}

		public void Producir(Producto producto)
		{
			cooperativa.Gastar(producto.Precio);

			this.producto = producto;					
		}
	}
}
