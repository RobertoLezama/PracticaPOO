using PracticaPOO.Clases;
using System;
using System.Collections.Generic;

namespace PracticaPOO
{
    public class Cooperativa
    {
        CentroAcopio bodegas;
        Finca finca;
        List<Lote> lotes;

        public decimal Dinero { get; private set; }

        public Cooperativa()
        {
            bodegas = new CentroAcopio(10);
            lotes = new List<Lote>(5);

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
            if (Dinero > monto)
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

        public void LotesProducto()
        {
            lotes.Add(new Lote("Lote 1", new Grano {Tipo = Enums.Grano.Maíz }));
            lotes.Add(new Lote("Lote 2", new Fruta {Tipo = Enums.Fruta.Fresa }));
            lotes.Add(new Lote("Lote 3", new Legumbre {Tipo = Enums.Legumbre.Frijoles}));
            lotes.Add(new Lote("Lote 4", new Semilla {Tipo = Enums.Semilla.Maní}));
           
            finca = new Finca(lotes, 5); //Se instancia la finca para poder usar el método imprimir que esta en la clase finca.
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

        public void Cultivar()
        { 
        }

        #endregion
    }
}
