namespace PracticaPOO
{
    public class Fruta : ProdVegetal
    {
		public Enums.Fruta Tipo { get; set; }

		public Fruta() : base("Fruta", 100, 1) { }

		public Fruta (Enums.Fruta tipo) : this()
		{
			this.Tipo = tipo;
		}
	}
}
