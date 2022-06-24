using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTable
{
    public class Table
    {
        private const string ArticulacionSuperiorIzaquierda = "┌";
        private const string ArticulacionSuperiorDerecha = "┐";
        private const string ArticulacionInferiorIzquierda = "└";
        private const string ArticulacionInferiorDerecha = "┘";
        private const string ArticulacionSuperior = "┬";
        private const string ArticulaciónInferior = "┴";
        private const string ArtculacionIzquierda = "├";
        private const string ArticulacionMedia = "┼";
        private const string ArticulacionDerecha = "┤";
        private const char LineaHorizontal = '─';
        private const string LineaVertical = "│";

        private string[] _Encabezados;
        private List<string[]> _filas = new List<string[]>();

        public int Relleno { get; set; } = 1;
        public bool TextoEncabezadoAlinearDerecha { get; set; }
        public bool AlinearTextoFilaDerecha { get; set; }

        public void EstablecerEncabezados(params string[] encabezados)
        {
            _Encabezados = encabezados;
        }

        public void AñadirFila(params string[] fila)
        {
            _filas.Add(fila);
        }

        public void BorrarFilas()
        {
            _filas.Clear();
        }

        private int[] ObtenerAnchoMaximoCelda(List<string[]> tabla)
        {
            var columnasMaximas = 0;
            foreach (var fila in tabla)
            {
                if (fila.Length > columnasMaximas)
                    columnasMaximas = fila.Length;
            }

            var anchoCeldaMaximo = new int[columnasMaximas];
            for (int i = 0; i < anchoCeldaMaximo.Count(); i++)
                anchoCeldaMaximo[i] = 0;

            var conteoRelleno = 0;
            if (Relleno > 0)
            {
                //Padding is left and right
                conteoRelleno = Relleno * 2;
            }

            foreach (var fila in tabla)
            {
                for (int i = 0; i < fila.Length; i++)
                {
                    var anchuraMaxima = fila[i].Length + conteoRelleno;

                    if (anchuraMaxima > anchoCeldaMaximo[i])
                        anchoCeldaMaximo[i] = anchuraMaxima;
                }
            }

            return anchoCeldaMaximo;
        }

        private StringBuilder CrearLineaSuperior(int[] anchoCeldaMaximo, int conteoFilasYColumnas, StringBuilder tablaFormateada)
        {
            for (int i = 0; i < conteoFilasYColumnas; i++)
            {
                if (i == 0 && i == conteoFilasYColumnas - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionSuperiorIzaquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionSuperiorDerecha));
                else if (i == 0)
                    tablaFormateada.Append(string.Format("{0}{1}", ArticulacionSuperiorIzaquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                else if (i == conteoFilasYColumnas - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionSuperior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionSuperiorDerecha));
                else
                    tablaFormateada.Append(string.Format("{0}{1}", ArticulacionSuperior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
            }

            return tablaFormateada;
        }

        private StringBuilder CrearLineaDeFondo(int[] anchoCeldaMaximo, int conteoFilasYColumnas, StringBuilder tablaFormateada)
        {
            for (int i = 0; i < conteoFilasYColumnas; i++)
            {
                if (i == 0 && i == conteoFilasYColumnas - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionInferiorIzquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionInferiorDerecha));
                else if (i == 0)
                    tablaFormateada.Append(string.Format("{0}{1}", ArticulacionInferiorIzquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                else if (i == conteoFilasYColumnas - 1)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulaciónInferior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionInferiorDerecha));
                else
                    tablaFormateada.Append(string.Format("{0}{1}", ArticulaciónInferior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
            }

            return tablaFormateada;
        }

        private StringBuilder CrearValorDeLinea(int[] anchoCeldaMaximo, string[] fila, bool alinearDerecha, StringBuilder tablaFormateada)
        {
            int indiceDeCelda = 0;
            int indiceUltimaCelda = fila.Length - 1;

            var cadenaDeRelleno = string.Empty;
            if (Relleno > 0)
                cadenaDeRelleno = string.Concat(Enumerable.Repeat(' ', Relleno));

            foreach (var columna in fila)
            {
                var restoDeAncho = anchoCeldaMaximo[indiceDeCelda];
                if (Relleno > 0)
                    restoDeAncho -= Relleno * 2;

                var valorDeCelda = alinearDerecha ? columna.PadLeft(restoDeAncho, ' ') : columna.PadRight(restoDeAncho, ' ');

                if (indiceDeCelda == 0 && indiceDeCelda == indiceUltimaCelda)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}{3}{4}", LineaVertical, cadenaDeRelleno, valorDeCelda, cadenaDeRelleno, LineaVertical));
                else if (indiceDeCelda == 0)
                    tablaFormateada.Append(string.Format("{0}{1}{2}{3}", LineaVertical, cadenaDeRelleno, valorDeCelda, cadenaDeRelleno));
                else if (indiceDeCelda == indiceUltimaCelda)
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}{3}{4}", LineaVertical, cadenaDeRelleno, valorDeCelda, cadenaDeRelleno, LineaVertical));
                else
                    tablaFormateada.Append(string.Format("{0}{1}{2}{3}", LineaVertical, cadenaDeRelleno, valorDeCelda, cadenaDeRelleno));

                indiceDeCelda++;
            }

            return tablaFormateada;
        }

        private StringBuilder CrearLineaDeSeparacion(int[] anchoCeldaMaximo, int conteoAnteriorFilasYColumnas, int conteoFilasYColumnas, StringBuilder tablaFormateada)
        {
            var celdasMaximas = Math.Max(conteoAnteriorFilasYColumnas, conteoFilasYColumnas);

            for (int i = 0; i < celdasMaximas; i++)
            {
                if (i == 0 && i == celdasMaximas - 1)
                {
                    tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArtculacionIzquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionDerecha));
                }
                else if (i == 0)
                {
                    tablaFormateada.Append(string.Format("{0}{1}", ArtculacionIzquierda, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                }
                else if (i == celdasMaximas - 1)
                {
                    if (i > conteoAnteriorFilasYColumnas)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionSuperior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionSuperiorDerecha));
                    else if (i > conteoFilasYColumnas)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulaciónInferior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionInferiorDerecha));
                    else if (i > conteoAnteriorFilasYColumnas - 1)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionMedia, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionSuperiorDerecha));
                    else if (i > conteoFilasYColumnas - 1)
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionMedia, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionInferiorDerecha));
                    else
                        tablaFormateada.AppendLine(string.Format("{0}{1}{2}", ArticulacionMedia, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal), ArticulacionDerecha));
                }
                else
                {
                    if (i > conteoAnteriorFilasYColumnas)
                        tablaFormateada.Append(string.Format("{0}{1}", ArticulacionSuperior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                    else if (i > conteoFilasYColumnas)
                        tablaFormateada.Append(string.Format("{0}{1}", ArticulaciónInferior, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                    else
                        tablaFormateada.Append(string.Format("{0}{1}", ArticulacionMedia, string.Empty.PadLeft(anchoCeldaMaximo[i], LineaHorizontal)));
                }
            }

            return tablaFormateada;
        }

        public override string ToString()
        {
            var tabla = new List<string[]>();

            var primerFilaEsEncabezado = false;
            if (_Encabezados?.Any() == true)
            {
                tabla.Add(_Encabezados);
                primerFilaEsEncabezado = true;
            }

            if (_filas?.Any() == true)
                tabla.AddRange(_filas);

            if (!tabla.Any())
                return string.Empty;

            var tablaFormateada = new StringBuilder();

            var filaAnterior = tabla.FirstOrDefault();
            var filaSiguiente = tabla.FirstOrDefault();

            int[] anchoCeldaMaximo = ObtenerAnchoMaximoCelda(tabla);

            tablaFormateada = CrearLineaSuperior(anchoCeldaMaximo, filaSiguiente.Count(), tablaFormateada);

            int indiceFila = 0;
            int indiceUltimaFila = tabla.Count - 1;

            for (int i = 0; i < tabla.Count; i++)
            {
                var fila = tabla[i];

                var alinear = AlinearTextoFilaDerecha;
                if (i == 0 && primerFilaEsEncabezado)
                    alinear = TextoEncabezadoAlinearDerecha;

                tablaFormateada = CrearValorDeLinea(anchoCeldaMaximo, fila, alinear, tablaFormateada);

                filaAnterior = fila;

                if (indiceFila != indiceUltimaFila)
                {
                    filaSiguiente = tabla[indiceFila + 1];
                    tablaFormateada = CrearLineaDeSeparacion(anchoCeldaMaximo, filaAnterior.Count(), filaSiguiente.Count(), tablaFormateada);
                }

                indiceFila++;
            }

            tablaFormateada = CrearLineaDeFondo(anchoCeldaMaximo, filaAnterior.Count(), tablaFormateada);

            return tablaFormateada.ToString();
        }
    }
}
