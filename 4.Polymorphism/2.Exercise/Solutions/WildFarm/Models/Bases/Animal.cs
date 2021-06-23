using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm.Models.Bases
{
    public abstract class Animal
    {
        public Animal()
        {
        }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        protected int FoodEaten { get; set; }
        protected string Name { get; set; }
        protected abstract List<string> TolerableFood { get; set; }
        protected double Weight { get; set; }
        protected abstract double weightModifier { get; }

        public virtual void Eat(Food food)
        {
            if (TolerableFood.Contains(food.GetType().Name))
            {
                FoodEaten += food.Weight;
                Weight += food.Weight * weightModifier;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public abstract void FeedMe();
    }
}