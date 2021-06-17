using Military.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Military
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string initialInput = Console.ReadLine();

            List<Soldier> soldiers = new List<Soldier>();

            while (initialInput != "End")
            {
                string[] inputArgs = initialInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string solderType = inputArgs[0];
                string id = inputArgs[1];
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];
                decimal salary = decimal.Parse(inputArgs[4]);

                switch (solderType)
                {
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        List<string> exceptions = new List<string>();
                        List<Private> privatesToAdd = new List<Private>();

                        for (int i = 0; i < 5; i++)
                        {
                            exceptions.Add(inputArgs[i]);
                        }

                        foreach (var privatesIds in inputArgs.Except(exceptions).ToArray())
                        {
                            foreach (Private privateObj in soldiers.Where(s => s.ID == privatesIds))
                            {
                                privatesToAdd.Add(privateObj);
                            }
                        }

                        soldiers.Add(new LieutenantGeneral
                            (id, firstName, lastName, salary, privatesToAdd));
                        break;
                    case "Engineer":
                        string corp = inputArgs[5];

                        List<string> engExceptions = new List<string>();

                        for (int i = 0; i < 6; i++)
                        {
                            engExceptions.Add(inputArgs[i]);
                        }
                        try
                        {
                            soldiers.Add
                                 (new Engineer
                                 (id, firstName, lastName, salary, corp, inputArgs
                                 .Except(engExceptions).ToArray()));
                        }
                        catch (Exception)
                        {
                        }

                        break;
                    case "Commando":
                        string corpCom = inputArgs[5];

                        List<string> comExceptions = new List<string>();

                        for (int i = 0; i < 6; i++)
                        {
                            comExceptions.Add(inputArgs[i]);
                        }

                        try
                        {
                            soldiers.Add
                             (new Commando
                             (id, firstName, lastName, salary, corpCom, inputArgs
                             .Except(comExceptions).ToArray()));
                        }
                        catch (Exception)
                        {
                        }

                        break;
                    case "Spy":
                        soldiers.Add(new Spy(id, firstName, lastName, Convert.ToInt32(salary)));
                        break;
                }

                initialInput = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.Write(soldier);
            }
        }
    }
}
