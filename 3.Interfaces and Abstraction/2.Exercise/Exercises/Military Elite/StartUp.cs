using Military.Models;
using Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Military
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IPrivate> privatesList = new List<IPrivate>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                switch (soldierType)
                {
                    case "Private":

                        decimal prSalary = decimal.Parse(inputArgs[4]);
                        Private privateSoldier = new Private(id, firstName, lastName, prSalary);
                        privatesList.Add(privateSoldier);
                        Console.WriteLine(privateSoldier);

                        break;

                    case "LieutenantGeneral":

                        decimal lieuSalary = decimal.Parse(inputArgs[4]);
                        LieutenantGeneral generalSoldier = new LieutenantGeneral(id, firstName, lastName, lieuSalary);

                        List<int> privateIdsUnderCommand = new List<int>();

                        for (int i = 5; i < inputArgs.Length; i++)
                        {
                            privateIdsUnderCommand.Add(int.Parse(inputArgs[i]));
                        }

                        foreach (var idNumber in privateIdsUnderCommand)
                        {
                            if (privatesList.FirstOrDefault(x => x.Id == idNumber) != null)
                            {
                                generalSoldier.AddPrivate(privatesList.First(x => x.Id == idNumber));
                            }
                        }

                        Console.WriteLine(generalSoldier);

                        break;

                    case "Engineer":

                        decimal engSalary = decimal.Parse(inputArgs[4]);
                        string engCorp = inputArgs[5];

                        try
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, engSalary, engCorp);

                            string partName = null;
                            int hoursWorked = 0;

                            for (int i = 6; i < inputArgs.Length; i += 2)
                            {
                                partName = inputArgs[i];
                                hoursWorked = int.Parse(inputArgs[i + 1]);

                                engineer.AddRepair(new Repair(partName, hoursWorked));
                            }

                            Console.WriteLine(engineer);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        break;

                    case "Commando":

                        decimal comSalary = decimal.Parse(inputArgs[4]);
                        string comCorp = inputArgs[5];

                        try
                        {
                            Commando commando = new Commando(id, firstName, lastName, comSalary, comCorp);

                            string missionName = null;
                            string state = null;

                            for (int i = 6; i < inputArgs.Length; i += 2)
                            {
                                missionName = inputArgs[i];
                                state = inputArgs[i + 1];

                                try
                                {
                                    commando.AddMission(new Mission(missionName, state));
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            Console.WriteLine(commando);

                        }
                        catch (Exception)
                        {
                            break;
                        }

                        break;

                    case "Spy":

                        int codeNumber = int.Parse(inputArgs[4]);

                        Spy spy = new Spy(id, firstName, lastName, codeNumber);

                        Console.WriteLine(spy);

                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
