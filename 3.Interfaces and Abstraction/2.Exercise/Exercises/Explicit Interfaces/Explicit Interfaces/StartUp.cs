using Explicit_Interfaces.Interfaces;
using Explicit_Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Explicit
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                citizens.Add(new Citizen(name, country, age));

                input = Console.ReadLine();
            }

            foreach (var citizen in citizens)
            {
                (citizen as ICitizen).GetName();
                (citizen as IResident).GetName();
            }
        }
    }
}
