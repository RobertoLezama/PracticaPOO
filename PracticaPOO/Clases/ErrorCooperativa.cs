using System;

namespace PracticaPOO.Clases
{
    public class ErrorCooperativa : Exception
    {
        public ErrorCooperativa(string mensaje) : base(mensaje) { }
    }
}