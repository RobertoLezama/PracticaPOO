namespace PracticaPOO
{
    public class Semilla : ProdVegetal
    {
		public Enums.Semilla Tipo { get; set; }

		public Semilla() : base("Semilla", 100, 1) { }

		public Semilla(Enums.Semilla tipo) : this()
		{
			this.Tipo = tipo;
		}
	}
}
