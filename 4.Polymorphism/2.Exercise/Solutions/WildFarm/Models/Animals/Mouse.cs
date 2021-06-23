using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            TolerableFood = new List<string>()
            {
                "Fruit",
                "Vegetable"
            };
        }

        protected override List<string> TolerableFood { get; set; }

        protected override double weightModifier => 0.10;

        public override void FeedMe()
        {
            Console.WriteLine("Squeak");
        }
    }
}