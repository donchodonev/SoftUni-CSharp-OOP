using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Bases;

namespace WildFarm.Factories
{
    public class BirdFactory : AnimalFactory
    {
        public BirdFactory(string animalType, string name, double weight, double wingSize)
            : base(animalType, name, weight)
        {
            WingSize = wingSize;
        }

        private double WingSize { get; }

        public override Animal CreateAnimal()
        {
            Bird bird = null;

            switch (Type)
            {
                case "Owl":
                    bird = new Owl(Name, Weight, WingSize);
                    break;

                case "Hen":
                    bird = new Hen(Name, Weight, WingSize);
                    break;
            }

            return bird;
        }
    }
}