using PracticaPOO.Clases;
using System;

namespace PracticaPOO
{
    public class Cooperativa
    {
        CentroAcopio bodegas;
        Finca finca;

        public decimal Dinero { get; private set; }

        public Cooperativa()
        {
            bodegas = new CentroAcopio(10);
            finca = new Finca(this, 5);
        }

        #region Control Contable

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
            if (Dinero >= monto)
            {
                Dinero -= monto;
            }
            else
                throw new ErrorCooperativa("No hay saldo para retirar ese monto");
        }

        #endregion

        #region Control de Inventarios

        public void SimularExistenciasDeProductos()
        {
            bodegas.GuardarProducto(new Leche());
            bodegas.GuardarProducto(new Leche());

            bodegas.GuardarProducto(new Huevos());
            bodegas.GuardarProducto(new Huevos());
            bodegas.GuardarProducto(new Huevos());

            bodegas.GuardarProducto(new Fruta { Tipo = Enums.Fruta.Fresa });
            bodegas.GuardarProducto(new Fruta { Tipo = Enums.Fruta.Fresa });
            bodegas.GuardarProducto(new Fruta { Tipo = Enums.Fruta.Mora });
            bodegas.GuardarProducto(new Fruta { Tipo = Enums.Fruta.Piña });
        }

        public void ImprimirInventario()
        {
            bodegas.ImprimirReporte();
        }

        public void RptImprimirCultivos()
        {
            finca.ImprimirLotes();
        }

        #endregion

        #region Producción

        public void Cultivar(ProdVegetal producto)
        { 
            finca.Cultivar(producto);
        }

        #endregion
    }
}
