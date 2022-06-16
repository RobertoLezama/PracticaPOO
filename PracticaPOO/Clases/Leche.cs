namespace PracticaPOO
{
    public class Leche : ProdAnimal
    {
        public Leche() : base("Leche", 100, 1) { }
    }

    public class Huevos : ProdAnimal
    {
        public Huevos() : base("Huevos", 200, 2) { }
    }

    public class Pollo : ProdAnimal
    {
        public Pollo() : base("Pollo", 500, 3) { }
    }

    public class Cerdo : ProdAnimal
    {
        public Cerdo() : base("Cerdo", 1000, 5) { }
    }

    public class Res : ProdAnimal
    {
        public Res() : base("Res", 2000, 8) { }
    }
}
