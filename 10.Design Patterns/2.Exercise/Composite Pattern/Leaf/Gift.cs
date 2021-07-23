using System;
using System.Collections.Generic;
using System.Text;
using Composite_Pattern.Component;

namespace Composite_Pattern.Leaf
{
    public class Gift : GiftBase
    {
        public Gift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override void Add(GiftBase gift)
        {
            Console.WriteLine($"Only gift composites can hold other gifts");
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{name} has a price of {price}");
            return this.price;
        }

        public override void Remove(GiftBase gift)
        {
            Console.WriteLine($"Only gift composites can remove other gifts");
        }
    }
}
