using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Bases;

namespace WildFarm
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Animal> animalCollection = new List<Animal>();
            AnimalFactory animalFactory = null; ;
            FoodFactory foodFactory = null;

            Animal animal = null;
            Food food = null;
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArgs[0];
                string name = cmdArgs[1];
                double weight = double.Parse(cmdArgs[2]);

                switch (type)
                {
                    case "Mouse":
                    case "Dog":
                        string mammalRegion = cmdArgs[3];
                        animalFactory = new MammalFactory(type, name, weight, mammalRegion);
                        animal = animalFactory.CreateAnimal();
                        break;

                    case "Cat":
                    case "Tiger":

                        string felineRegion = cmdArgs[3];
                        string breed = cmdArgs[4];
                        animalFactory = new FelineFactory(type, name, weight, felineRegion, breed);
                        animal = animalFactory.CreateAnimal();

                        break;

                    case "Owl":
                    case "Hen":
                        double wingSize = double.Parse(cmdArgs[3]);
                        animalFactory = new BirdFactory(type, name, weight, wingSize);
                        animal = animalFactory.CreateAnimal();

                        break;
                }

                animal.FeedMe();

                string[] foodParams = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodParams[0];
                int foodWeight = int.Parse(foodParams[1]);

                foodFactory = new FoodFactory(foodType, foodWeight);
                food = foodFactory.CreateFood();

                animal.Eat(food);

                animalCollection.Add(animal);

                command = Console.ReadLine();
            }

            foreach (var item in animalCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}