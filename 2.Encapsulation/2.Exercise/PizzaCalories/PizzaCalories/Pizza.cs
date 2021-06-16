using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        public int NumberOfToppings => Toppings.Count;
        private Dough dough;
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (value.Length < 1 || value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        private List<Topping> Toppings { get; set; }

        public Dough Dough
        {
            private get => dough;
            set 
            {
                dough = value; 
            }
        }

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public double TotalCalories() 
        {
            double toppingCalories = 0.0;

            Toppings.ForEach(topping => toppingCalories += topping.TotalCalories());
            toppingCalories += Dough.TotalCalories();

            return toppingCalories;
        }
        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{Name} - {TotalCalories():F2} Calories.";
        }
    }
}