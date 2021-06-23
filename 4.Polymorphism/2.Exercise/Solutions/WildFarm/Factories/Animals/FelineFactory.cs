using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Bases;

namespace WildFarm.Factories
{
    public class FelineFactory : AnimalFactory
    {
        public FelineFactory(string animalType, string name, double weight, string livingRegion, string breed)
            : base(animalType, name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }

        protected string Breed { get; set; }
        protected string LivingRegion { get; set; }

        public override Animal CreateAnimal()
        {
            Feline feline = null;

            switch (Type)
            {
                case "Cat":
                    feline = new Cat(Name, Weight, LivingRegion, Breed);
                    break;

                case "Tiger":
                    feline = new Tiger(Name, Weight, LivingRegion, Breed);
                    break;
            }

            return feline;
        }
    }
}