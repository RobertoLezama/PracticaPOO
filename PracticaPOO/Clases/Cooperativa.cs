using System;
using System.Collections.Generic;

namespace PracticaPOO
{
    public class Cooperativa
    {
        CentroAcopio bodegas;
        List<Lote> lotes;

        public decimal Dinero { get; private set; }

        public Cooperativa()
        {
            bodegas = new CentroAcopio(10);
            lotes = new List<Lote>();
        }

        public void Abonar(decimal monto)
        {
            if (monto < 0)
            {
                throw new Exception("No puede abonar un monto negativo");
            }

            Dinero += monto;
        }

        public void Gastar(decimal monto)
        {
            if (Dinero > monto)
            {
                Dinero -= monto;
            }
            else
                throw new Exception("No hay saldo para retirar ese monto");
        }
    }
}
