using PracticaPOO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticaPOO
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Instancias de las clases con los parámetros
            ProdVegetal vegetal = new ProdVegetal("Café", 500, 4);
            Console.WriteLine(vegetal.Nombre);
           

            ProdAnimal animal = new ProdAnimal("leche", 100, 1);
            Console.WriteLine(animal.Precio);


            //var granero = new CentroAcopio(1, 50, 30, 20, 1, 0);
            //Console.WriteLine(granero.Capacidad);

            //var granja = new Granja("Lecheria Familia Duran", TipoGranja.Lechería, TipoProducto.Leche, 3,3);
            //Console.WriteLine(granja.Nombre);
            //Console.ReadLine();

           

        }  
    }


}

