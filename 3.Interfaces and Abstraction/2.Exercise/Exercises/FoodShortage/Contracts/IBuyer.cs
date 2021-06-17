using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer : INameable
    {
        public int Food { get; set; }
        public void BuyFood();
    }
}
