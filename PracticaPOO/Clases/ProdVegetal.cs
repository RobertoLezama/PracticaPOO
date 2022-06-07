namespace PracticaPOO
{
    public class ProdVegetal : Producto
    {

        /// <summary>Tiempo de Cultivo</summary>
        public override int Tiempo { get; set; }

        //Metodo constructor el cual hereda de la clase principal junto con sus parametros
        public ProdVegetal(string nombre, decimal precio, int tiempoCultivo) : base(nombre, precio) //Llama al constructor de la super clase
        {
            Tiempo = tiempoCultivo;
        }
    }
}
