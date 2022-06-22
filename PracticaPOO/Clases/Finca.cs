using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaPOO.Clases
{
    public class Finca
    {
        List<Lote> lotes;

        Cooperativa cooperativa;

        public int Capacidad { get; private set; }

        public int TotalLotes => lotes.Count;

        public int TotalLotesDisponibles => Capacidad - lotes.Count;

        public Finca(Cooperativa coop, int capacidad)
        {
            this.cooperativa = coop;
            this.lotes = new List<Lote>();

            Capacidad = capacidad;
        }

        public bool Cultivar(Producto producto)
        {
            if (lotes.Count >= Capacidad)
            {
                throw new Exception("No hay capacidad suficiente para Cultivar el producto: " + producto);
            }

            lotes.Add(new Lote(cooperativa, producto));
            return true;
        }

        //Aquí va su método
        public void ImprimirLotes()
        {
            if (lotes.Count > Capacidad)
            {
                throw new Exception("No hay capacidad suficiente para Cultivar en el Lote:" + lotes);
            }

            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            int tamProdMax = this.lotes.Max(p => p.Producto.Nombre.Length);
            int tamLotMax = 5;
            tamProdMax = tamProdMax > 8 ? tamProdMax : 8;
            tamLotMax = tamLotMax > 4 ? tamLotMax : 4;

            string template = "│  {0," + tamLotMax + "}   │  {1," + tamProdMax + "}   │";

            Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);
            string esquinaSuper = new string('─', tamLotMax + 21).Substring(0, 1).Replace('─', '┌') +
                new string('─', tamLotMax + 21).Substring(1, tamLotMax + 5)
            + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, 1).Replace('─', '┬')
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, tamProdMax + 5)
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 20).Replace('─', '┐');
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(esquinaSuper);

            Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);
            Console.WriteLine(string.Format(template, "Lote".PadRight(tamLotMax, ' '), "Producto".PadRight(tamProdMax, ' ')));


            Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);

            string esquinaMedio = new string('─', tamLotMax + 21).Substring(0, 1).Replace('─', '├')
                + new string('─', tamLotMax + 21).Substring(1, tamLotMax + 5)
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, 1).Replace('─', '┼')
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, tamProdMax + 5)
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 20).Replace('─', '┤');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(esquinaMedio);

            //Me trae el lote y el producto.
            for (int i = 0; i < this.lotes.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);
                Console.WriteLine(string.Format(template, (i + 1).ToString(), this.lotes[i].Producto.ToString().PadRight(tamProdMax, ' ')));
            }

            Console.SetCursorPosition((Console.WindowWidth - (tamLotMax + tamProdMax + 13)) / 2, Console.CursorTop);
            string esquina = new string('─', tamLotMax + 21).Substring(0, 1).Replace('─', '└')
                + new string('─', tamLotMax + 21).Substring(1, tamLotMax + 5)
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, 1).Replace('─', '┴')
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 6, tamProdMax + 5)
                + new string('─', tamLotMax + 21).Substring(tamLotMax + 20).Replace('─', '┘');

            Console.WriteLine(esquina);

            //Imprimir Existencias / Capacidad

            int cant = this.lotes.Count;

            string cuadro = "│  {0," + 9 + "}   │  {1," + 11 + "}   │";
            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            string esquinaSuperiorCuadro = new string('─', 33).Substring(0, 1).Replace('─', '┌') +
                new string('─', 33).Substring(1, 14)
                + new string('─', 33).Substring(15, 1).Replace('─', '┬')
                + new string('─', 33).Substring(16, 16)
                + new string('─', 33).Substring(32).Replace('─', '┐');
            Console.WriteLine(esquinaSuperiorCuadro);
            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            Console.WriteLine(string.Format(cuadro, "Capacidad", "Produciendo"));
            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            string esquinaCuadroMedio = new string('─', 33).Substring(0, 1).Replace('─', '├')
               + new string('─', 33).Substring(1, 14)
               + new string('─', 33).Substring(15, 1).Replace('─', '┼')
               + new string('─', 33).Substring(16, 16)
               + new string('─', 33).Substring(32).Replace('─', '┤');
            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            Console.WriteLine(esquinaCuadroMedio);

            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            Console.WriteLine(string.Format(cuadro, Capacidad, cant));
            Console.SetCursorPosition((Console.WindowWidth - 33) / 2, Console.CursorTop);
            string esquinaInferiorCuadro = new string('─', 33).Substring(0, 1).Replace('─', '└')
                + new string('─', 33).Substring(1, 14)
                + new string('─', 33).Substring(15, 1).Replace('─', '┴')
                + new string('─', 33).Substring(16, 16)
                + new string('─', 33).Substring(32).Replace('─', '┘');
            Console.WriteLine(esquinaInferiorCuadro);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Presione cualquier tecla para continuar . . .");


            Console.ReadKey();
        }
    }
}
