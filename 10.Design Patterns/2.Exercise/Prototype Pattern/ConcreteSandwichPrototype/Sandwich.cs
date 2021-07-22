using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Prototype_Pattern.AbstractSandwichPrototype;

namespace Prototype_Pattern.ConcretePrototype
{
    public class Sandwich : PrototypeSandwich
    {
        private string bread;

        private string cheese;

        private string meat;

        private string veggies;

        private string ingridientList;
        public Sandwich(string bread, string cheese, string meat, string veggies)
        {
            this.bread = bread;
            this.cheese = cheese;
            this.meat = meat;
            this.veggies = veggies;
            ingridientList = $"{bread}, {cheese}, {meat}, {veggies}";
        }
        public override PrototypeSandwich Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingreadients: {ingridientList}");
            return MemberwiseClone() as PrototypeSandwich;;
        }
    }
}
