using System;
using System.Collections.Generic;
using System.IO;

namespace _1.Lab
{
    //implementation different from SoftUni's as this makes much more sense
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance;

        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines("capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        //non-thread-safe
        //lazy initialization
        public static SingletonDataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonDataContainer();
                }

                return instance;
            }
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}