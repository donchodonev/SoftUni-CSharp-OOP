using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BASE_CALORIES = 2.0; // per gram
        private string toppingType;
        private double weight;
        private string toppingNameAsInput;
        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        private string ToppingType
        {
            get => toppingType;
            set 
            {
                toppingNameAsInput = value;
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        toppingType = value.ToLower();
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {toppingNameAsInput[0].ToString().ToUpper()}" +
                            $"{toppingNameAsInput.Substring(1).ToLower()} on top of your pizza.");
                }
            }
        }

        private double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingNameAsInput[0].ToString().ToUpper()}" +
                            $"{toppingNameAsInput.Substring(1).ToLower()} weight should be in the range[1..50].");
                }
                weight = value;
            }
        }

        public double TotalCalories()
        {
            double currentToppingTypeCalorie = default;

            switch (ToppingType.ToLower())
            {
                case "meat":
                    currentToppingTypeCalorie = 1.2;
                    break;
                case "veggies":
                    currentToppingTypeCalorie = 0.8;
                    break;
                case "cheese":
                    currentToppingTypeCalorie = 1.1;
                    break;
                case "sauce":
                    currentToppingTypeCalorie = 0.9;
                    break;
            }

            return BASE_CALORIES * Weight * currentToppingTypeCalorie;
        }
    }
}
