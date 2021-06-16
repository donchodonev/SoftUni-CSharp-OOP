using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BASE_CALORIES = 2.0;
        private string flour;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string bakingTechnique, double weight)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string Flour
        {
            get => flour;
            set
            {
                switch (value.ToLower())
                {
                    case "white":
                    case "wholegrain":
                        flour = value.ToLower();
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                    case "chewy":
                    case "homemade":
                        bakingTechnique = value.ToLower();
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }
        public double TotalCalories()
        {
            double flourCalories = default;
            double techniqueCalories = default;

            switch (Flour)
            {
                case "white":
                    flourCalories = 1.5;
                    break;
                case "wholegrain":
                    flourCalories = 1.0;
                    break;
            }

            switch (BakingTechnique)
            {
                case "crispy":
                    techniqueCalories = 0.9;
                    break;
                case "chewy":
                    techniqueCalories = 1.1;
                    break;
                case "homemade":
                    techniqueCalories = 1.0;
                    break;
            }

            return BASE_CALORIES * Weight * flourCalories * techniqueCalories;
        }
    }
}
