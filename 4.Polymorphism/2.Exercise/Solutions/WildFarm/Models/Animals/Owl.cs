using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Bases;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            TolerableFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override List<string> TolerableFood { get; set; }

        protected override double weightModifier => 0.25;

        public override void FeedMe()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}