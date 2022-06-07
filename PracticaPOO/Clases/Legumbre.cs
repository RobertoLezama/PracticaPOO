namespace PracticaPOO
{
    public class Legumbre : ProdVegetal
    {
		public Enums.Legumbre Tipo { get; set; }

		public Legumbre() : base("Legumbre", 100, 1) { }

		public Legumbre(Enums.Legumbre tipo) : this()
		{
			this.Tipo = tipo;
		}
	}
}
