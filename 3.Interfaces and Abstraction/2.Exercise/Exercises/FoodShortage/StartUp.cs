using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] buyerParams = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (buyerParams.Length == 4)
                {
                    string name = buyerParams[0];
                    int age = int.Parse(buyerParams[1]);
                    string id = buyerParams[2];
                    string birthday = buyerParams[3];

                    buyers.Add(new Citizen(name, age, id, birthday));
                }
                else
                {
                    string name = buyerParams[0];
                    int age = int.Parse(buyerParams[1]);
                    string group = buyerParams[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var buyer in buyers.Where(x => x.Name == input))
                {
                    buyer.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(buyer => buyer.Food));
        }
    }
}
