using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
                    : base(name, weight, livingRegion, breed)
        {
            TolerableFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override List<string> TolerableFood { get; set; }
        protected override double weightModifier => 1.00;

        public override void FeedMe()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}