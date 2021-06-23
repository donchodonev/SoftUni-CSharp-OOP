using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
                    : base(name, weight, livingRegion, breed)

        {
            TolerableFood = new List<string>()
            {
                "Meat",
                "Vegetable"
            };
        }

        protected override List<string> TolerableFood { get; set; }

        protected override double weightModifier => 0.30;

        public override void FeedMe()
        {
            Console.WriteLine("Meow");
        }
    }
}