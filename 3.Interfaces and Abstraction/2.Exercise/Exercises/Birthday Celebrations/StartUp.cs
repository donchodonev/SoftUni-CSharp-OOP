using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthable> robotsAndCitizens = new List<IBirthable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthday = inputArgs[4];

                    robotsAndCitizens.Add(new Citizen(name, age, id, birthday));
                }
                else if(inputArgs[0] == "Pet")
                {
                    string name = inputArgs[1];
                    string birthday = inputArgs[2];

                    robotsAndCitizens.Add(new Pet(name, birthday));
                }

                input = Console.ReadLine();

            }

            string birthdate = Console.ReadLine();

            foreach (var robotsAndCitizen in robotsAndCitizens
                .Where(x => x.Birthdate.EndsWith(birthdate)))
            {
                Console.WriteLine(robotsAndCitizen.Birthdate);
            }
        }
    }
}
