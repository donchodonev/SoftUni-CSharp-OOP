using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType = Console.ReadLine().ToLower();

            while (animalType != "beast!")
            {
                string [] animalArgs = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);
                string gender = animalArgs[2];

                if (animalType == "cat")
                {
                    try
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (animalType == "dog")
                {
                    try
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (animalType == "frog")
                {
                    try
                    {
                        animals.Add(new Frog(name, age, gender));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (animalType == "kitten")
                {
                    try
                    {
                        animals.Add(new Kitten(name, age));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (animalType == "tomcat")
                {
                    try
                    {
                        animals.Add(new Tomcat(name, age));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                animalType = Console.ReadLine().ToLower();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
