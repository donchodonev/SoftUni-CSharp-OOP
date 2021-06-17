using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> robotsAndCitizens = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    robotsAndCitizens.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    robotsAndCitizens.Add(new Robot(model, id));
                }

                input = Console.ReadLine();

            }

            string idEnding = Console.ReadLine();

            foreach (var robotsAndCitizen in robotsAndCitizens
                .Where(x => x.ID.EndsWith(idEnding)))
            {
                Console.WriteLine(robotsAndCitizen.ID);
            }
        }
    }
}
