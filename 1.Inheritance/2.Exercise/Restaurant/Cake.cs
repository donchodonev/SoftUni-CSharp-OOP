using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
             : base(name, CakePrice, Grams, Calories)
        {

        }
        private const double Grams = 250.0;
        private const double Calories = 1000.0;
        private const decimal CakePrice = 5M;
    }
}
