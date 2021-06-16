using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                Pizza pizza = new Pizza(Console.ReadLine().Split()[1]);

                string[] doughIngredients = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string flour = doughIngredients[1];
                string technique = doughIngredients[2];
                double weight = double.Parse(doughIngredients[3]);

                pizza.Dough = new Dough(flour, technique, weight);

                string toppings = Console.ReadLine();

                while (toppings != "END")
                {
                    string[] toppingParam = toppings
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string toppingName = toppingParam[1];
                    double toppingWeight = double.Parse(toppingParam[2]);

                    pizza.AddTopping(new Topping(toppingName, toppingWeight));

                    toppings = Console.ReadLine();
                }

                if (pizza.NumberOfToppings > 0)
                {
                    Console.WriteLine(pizza);
                }
                else
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
