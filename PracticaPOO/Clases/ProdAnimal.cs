namespace PracticaPOO
{
    public class ProdAnimal : Producto
    {
        /// <summary>Tiempo de Producción</summary>
        public override int Tiempo { get; set; }

        public ProdAnimal(string nombre, decimal precio, int tiempoProduccion) : base(nombre, precio, tiempoProduccion)
        {
            Tiempo = tiempoProduccion;
        }
    }
}
