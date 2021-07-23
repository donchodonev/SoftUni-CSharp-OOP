using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Composite_Pattern.Component;

namespace Composite_Pattern.Composite
{
    public class GiftComposite : GiftBase
    {
        private List<GiftBase> gifts;

        public GiftComposite(string name, decimal price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public override void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal sum = gifts.Sum(g => g.CalculateTotalPrice() + this.price);

            Console.WriteLine($"{name} contains the following gifts with total price: {sum}");

            return sum;
        }

        public override void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
