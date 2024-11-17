using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{

     // Classe Entity con proprietà
    public class Entity
    {
        public ValueObject.ProdName? Name { get; set; }
        public ValueObject.Code? Code { get; set; }
    }


   // Classe per i Value Object
    public class ValueObject
    {
        public record ProdName(string Name); // Record per ProdName
        public record Code(string Name);     // Record per Code
    }

}
