using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            TolerableFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override List<string> TolerableFood { get; set; }

        protected override double weightModifier => 0.40;

        public override void FeedMe()
        {
            Console.WriteLine("Woof!");
        }
    }
}