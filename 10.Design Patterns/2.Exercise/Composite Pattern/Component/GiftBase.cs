using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_Pattern.Component
{
    public abstract class GiftBase
    {
        protected string name;
        protected decimal price;

        protected GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract void Add(GiftBase gift);
        public abstract decimal CalculateTotalPrice();
        public abstract void Remove(GiftBase gift);
    }
}
