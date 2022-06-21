using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOO.Clases
{
    public class Finca
    {
       List<Lote> lotes;

        public int Capacidad { get; private set; }

        public int TotalLotes => lotes.Count;

        public int TotalLotesDisponibles => Capacidad - lotes.Count;

        public Finca(List<Lote> lotes, int capacidad)
        {
            this.lotes = lotes;

            Capacidad = capacidad;
        }

        public bool Cultivo(Lote lote)
        {
            if (lotes.Count >= Capacidad)
            {
                throw new Exception("No hay capacidad suficiente para Cultivar en el Lote: " + lote);
            }

            lotes.Add(lote);
            return true;
        }

        //Aquí va su método
    }
}
