using PracticaPOO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticaPOO.Program;

namespace PracticaPOO
{
   public class Legumbre : ProdVegetal
    {
		public Enums.Legumbre Tipo { get; set; }

		public Legumbre() : base("Legumbre", 500, 1) { }

		public Legumbre(Enums.Legumbre tipo) : this()
		{
			this.Tipo = tipo;
		}

		/*public void producir
        {

        }*/
	}
}
