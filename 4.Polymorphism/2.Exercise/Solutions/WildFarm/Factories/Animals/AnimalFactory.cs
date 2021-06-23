using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Factories
{
    public abstract class AnimalFactory
    {
        protected AnimalFactory(string animalType, string name, double weight)
        {
            Type = animalType;
            Name = name;
            Weight = weight;
        }

        protected string Name { get; set; }
        protected string Type { get; set; }
        protected double Weight { get; set; }

        public abstract Animal CreateAnimal();
    }
}