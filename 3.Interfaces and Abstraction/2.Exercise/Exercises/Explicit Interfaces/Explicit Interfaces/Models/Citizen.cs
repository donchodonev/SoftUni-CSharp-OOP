using Explicit_Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces.Models
{
    public class Citizen : IResident,ICitizen
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        void ICitizen.GetName()
        {
            Console.WriteLine($"{Name}");
        }
        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {Name}");
        }
    }
}
