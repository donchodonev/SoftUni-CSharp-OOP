using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Bases;

namespace WildFarm.Factories
{
    public class MammalFactory : AnimalFactory
    {
        public MammalFactory(string animalType, string name, double weight, string livingRegion)
            : base(animalType, name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override Animal CreateAnimal()
        {
            Mammal mammal = null;

            switch (Type)
            {
                case "Mouse":
                    mammal = new Mouse(Name, Weight, LivingRegion);
                    break;

                case "Dog":
                    mammal = new Dog(Name, Weight, LivingRegion);
                    break;
            }
            return mammal;
        }
    }
}