using PracticaPOO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaPOO.Program;

namespace PracticaPOO
{
    public class Grano : ProdVegetal
	{
		public Enums.Grano Tipo { get; set; }

		public Grano() : base("Grano", 300, 1) { }

		public Grano(Enums.Grano tipo) : this()
		{
			this.Tipo = tipo;
		}
	}
}
