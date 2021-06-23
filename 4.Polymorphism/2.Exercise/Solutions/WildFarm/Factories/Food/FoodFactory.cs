using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Bases;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public FoodFactory(string type, int quantity)
        {
            Quantity = quantity;
            Type = type;
        }

        private int Quantity { get; set; }
        private string Type { get; set; }

        public Food CreateFood()
        {
            Food food = null;

            switch (Type)
            {
                case "Fruit":
                    food = new Fruit(Quantity);
                    break;

                case "Meat":
                    food = new Meat(Quantity);
                    break;

                case "Seeds":
                    food = new Seeds(Quantity);
                    break;

                case "Vegetable":
                    food = new Vegetable(Quantity);
                    break;

                default:
                    break;
            }

            return food;
        }
    }
}