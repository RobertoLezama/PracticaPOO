namespace PracticaPOO
{
    public class Lote : IProductor
    {
        Cooperativa cooperativa;

        public Producto Producto { get; private set; }

        public Lote(Cooperativa coop)
        {
            cooperativa = coop;
        }

        public Lote(Cooperativa coop, Producto producto) : this(coop)
        {
            Producir(producto);
        }

        public void Producir(Producto producto)
        {
            cooperativa.Gastar(producto.Precio);

            this.Producto = producto;
        }
    }
}
