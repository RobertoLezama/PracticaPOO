using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consoletabla
{
    public class Tabla
    {
        private const string EsquinaSuperiorIzquierda = "┌";
        private const string EsquinaSuperiorDerecha = "┐";
        private const string EsquinaInferiorIzquierda = "└";
        private const string EsquinaInferiorDerecha = "┘";
        private const string UnionSuperior = "┬";
        private const string UnionInferior = "┴";
        private const string UnionIzquierda = "├";
        private const string UnionMedio = "┼";
        private const string UnionDerecha = "┤";
        private const char LineaHorizontal = '─';
        private const string LineaVertical = "│";

        private string[] _titulos;
        private List<string[]> _filas = new List<string[]>();

        public int Margen { get; set; } = 1;
        public int Separacion { get; set; } = 1;
        public bool AlineacionDerechaDeTitulo { get; set; }
        public bool AlineacionDerechaDeFila { get; set; }
        public bool EstaCentrado { get; set; }    

        public void EstablacerTitulos(params string[] titulos)
        {
            _titulos = titulos;
        }

        public void AgregarFila(params string[] fila)
        {
            _filas.Add(fila);
        }

        public void BorraFilas()
        {
            _filas.Clear();
        }

        private int[] ObtenerAnchoMaximo(List<string[]> tabla)
        {
            var maximoColumnas = 0;
            foreach (var fila in tabla)
            {
                if (fila.Length > maximoColumnas)
                   maximoColumnas = fila.Length;
            }
            
            var maximoCeldas = new int[maximoColumnas];
            for (int i = 0; i < maximoCeldas.Count(); i++)
                maximoCeldas[i] = 0;

            var TotalSeparacion = 0;
            if (Separacion > 0)
            {
                //Separacion es izquierda y derecha
                TotalSeparacion = Separacion * 2;
            }

            int valorMaximo = 0;
            foreach (var fila in tabla)
            {
                for (int i = 0; i < fila.Length; i++)
                {
                    var anchoMaximo = fila[i].Length + TotalSeparacion;

                    if (anchoMaximo > maximoCeldas[i])
                    {
                        maximoCeldas[i] = anchoMaximo;
                        valorMaximo = anchoMaximo;
                    }
                        
                }
            }
            //Se toma el valor maximo de cada columna para centrar la tabla.
            if (EstaCentrado)
                Margen = (Console.WindowWidth - valorMaximo) / 2;

            return maximoCeldas;
        }

        private StringBuilder CrearLineaSuperior(int[] anchoMaximo, int totalColumnasPorFila, StringBuilder tablaFormateada)
        {
            for (int i = 0; i < totalColumnasPorFila; i++)
            {
                if (i == 0 && i == totalColumnasPorFila - 1)
                    tablaFormateada.AppendLine(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}{2}", EsquinaSuperiorIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaSuperiorDerecha));
                else if (i == 0)
                    tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}", EsquinaSuperiorIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                else if (i == totalColumnasPorFila - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", UnionSuperior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaSuperiorDerecha));
                else
                    tablaFormateada.Append(string.Format("{0}{1}", UnionSuperior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
            }

            return tablaFormateada;
        }

        private StringBuilder CrearLineaInferior(int[] anchoMaximo, int totalColumnasPorFila, StringBuilder tablaFormateada)
        {
            for (int i = 0; i < totalColumnasPorFila; i++)
            {
                if (i == 0 && i == totalColumnasPorFila - 1)
                    tablaFormateada.AppendLine(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}{2}", EsquinaInferiorIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaInferiorDerecha));
                else if (i == 0)
                    tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}", EsquinaInferiorIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                else if (i == totalColumnasPorFila - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}",UnionInferior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaInferiorDerecha));
                else
                    tablaFormateada.Append(string.Format("{0}{1}",UnionInferior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
            }

            return tablaFormateada;
        }

        private StringBuilder CrearLineaDeValor(int[] anchoMaximo, string[] fila, bool alineacionDerecha, StringBuilder tablaFormateada)
        {
            int indiceCelda = 0;
            int ultimaCelda = fila.Length - 1;

            var SeparacionTexto = string.Empty;
            if (Separacion > 0)
                SeparacionTexto = string.Concat(Enumerable.Repeat(' ', Separacion));

            foreach (var columna in fila)
            {
                var anchoRestante = anchoMaximo[indiceCelda];
                if (Separacion > 0)
                    anchoRestante -= Separacion * 2;

                var valorDeCelda = alineacionDerecha ? columna.PadLeft(anchoRestante, ' ') : columna.PadRight(anchoRestante, ' ');

                if (indiceCelda == 0 && indiceCelda == ultimaCelda)
                    tablaFormateada.AppendLine(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}{2}{3}{4}", LineaVertical, SeparacionTexto, valorDeCelda, SeparacionTexto, LineaVertical));
                else if (indiceCelda == 0)
                    tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}{2}{3}", LineaVertical, SeparacionTexto, valorDeCelda, SeparacionTexto));
                else if (indiceCelda == ultimaCelda)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}{3}{4}", LineaVertical, SeparacionTexto, valorDeCelda, SeparacionTexto, LineaVertical));
                else
                    tablaFormateada.Append(string.Format("{0}{1}{2}{3}", LineaVertical, SeparacionTexto, valorDeCelda, SeparacionTexto));

                indiceCelda++;
            }

            return tablaFormateada;
        }

        private StringBuilder CrearLineaDeSeparacion(int[] anchoMaximo, int TotalAnteriorColumnasFila, int totalColumnasPorFila, StringBuilder tablaFormateada)
        {
            var maximoCeldas = Math.Max(TotalAnteriorColumnasFila, totalColumnasPorFila);

            for (int i = 0; i < maximoCeldas; i++)
            {
                if (i == 0 && i == maximoCeldas - 1)
                {
                    tablaFormateada.AppendLine(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}{2}",UnionIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), UnionDerecha));
                }
                else if (i == 0)
                {
                    tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}",UnionIzquierda, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                }
                else if (i == maximoCeldas - 1)
                {
                    if (i > TotalAnteriorColumnasFila)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", UnionSuperior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaSuperiorDerecha));
                    else if (i > totalColumnasPorFila)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}",UnionInferior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaInferiorDerecha));
                    else if (i > TotalAnteriorColumnasFila - 1)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}",UnionMedio, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaSuperiorDerecha));
                    else if (i > totalColumnasPorFila - 1)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}",UnionMedio, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), EsquinaInferiorDerecha));
                    else
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}",UnionMedio, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal), UnionDerecha));
                }
                else
                {
                    if (i > TotalAnteriorColumnasFila)
                        tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}", UnionSuperior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                    else if (i > totalColumnasPorFila)
                        tablaFormateada.Append(string.Format(string.Empty.PadLeft(Margen) + "{0}{1}",UnionInferior, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                    else
                        tablaFormateada.Append(string.Format("{0}{1}",UnionMedio, string.Empty.PadLeft(anchoMaximo[i], LineaHorizontal)));
                }
            }

            return tablaFormateada;
        }

        public override string ToString()
        {
            var tabla = new List<string[]>();

            var primerFilaEsTitulo = false;
            if (_titulos?.Any() == true)
            {
                tabla.Add(_titulos);
                primerFilaEsTitulo = true;
            }

            if (_filas?.Any() == true)
                tabla.AddRange(_filas);

            if (!tabla.Any())
                return string.Empty;

            var tablaFormateada = new StringBuilder();

            var filaAnterior = tabla.FirstOrDefault();
            var filaSiguiente = tabla.FirstOrDefault();

            int[] anchoMaximo = ObtenerAnchoMaximo(tabla);

            tablaFormateada = CrearLineaSuperior(anchoMaximo,filaSiguiente.Count(), tablaFormateada);

            int indiceDeFila = 0;
            int ultimoIndiceFila = tabla.Count - 1;//A la tabla le quita 1 para saber que va a dibujar la ultima fila.

            for (int i = 0; i < tabla.Count; i++)
            {
                var fila = tabla[i];

                var alinear =AlineacionDerechaDeFila;
                if (i == 0 && primerFilaEsTitulo)
                    alinear = AlineacionDerechaDeTitulo;

                tablaFormateada = CrearLineaDeValor(anchoMaximo, fila, alinear, tablaFormateada);

               filaAnterior = fila;

                if (indiceDeFila != ultimoIndiceFila)
                {
                   filaSiguiente = tabla[indiceDeFila + 1];
                    tablaFormateada = CrearLineaDeSeparacion(anchoMaximo,filaAnterior.Count(),filaSiguiente.Count(), tablaFormateada);
                }

                indiceDeFila++;
            }

            tablaFormateada = CrearLineaInferior(anchoMaximo,filaAnterior.Count(), tablaFormateada);

            return tablaFormateada.ToString();
        }
    }
}
