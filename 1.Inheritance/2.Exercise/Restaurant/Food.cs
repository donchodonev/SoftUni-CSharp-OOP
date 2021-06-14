using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams)
            :base(name, price)
        {
            Name = name;
            Price = price;
            Grams = grams;
        }
        public string  Name { get; set; }
        public decimal Price { get; set; }
        public double Grams { get; set; }
    }
}
