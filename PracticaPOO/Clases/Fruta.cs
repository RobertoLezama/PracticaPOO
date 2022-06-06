using PracticaPOO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaPOO.Program;

namespace PracticaPOO
{
    public class Fruta : ProdVegetal
    {
		public Enums.Fruta Tipo { get; set; }

		public Fruta() : base("Fruta", 400, 1) { }

		public Fruta (Enums.Fruta tipo) : this()
		{
			this.Tipo = tipo;
		}
	}
}
