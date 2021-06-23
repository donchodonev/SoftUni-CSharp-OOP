using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<string> TolerableFood { get; set; }

        protected override double weightModifier => 0.35;

        public override void Eat(Food food)
        {
            FoodEaten += food.Weight;
            Weight += food.Weight * weightModifier;
        }

        public override void FeedMe()
        {
            Console.WriteLine("Cluck");
        }
    }
}