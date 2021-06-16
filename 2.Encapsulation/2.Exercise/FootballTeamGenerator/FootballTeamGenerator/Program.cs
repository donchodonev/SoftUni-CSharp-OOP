using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command.Split(';');
                string action = cmdArgs[0];

                if (action == "Team")
                {
                    string teamName = cmdArgs[1];

                    if (!teams.ContainsKey(teamName))
                    {
                        try
                        {
                            teams.Add(cmdArgs[1], new Team(teamName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (action == "Add")
                {
                    string teamName = cmdArgs[1];
                    string playerName = cmdArgs[2];
                    int endurance = int.Parse(cmdArgs[3]);
                    int sprint = int.Parse(cmdArgs[4]);
                    int dribble = int.Parse(cmdArgs[5]);
                    int passing = int.Parse(cmdArgs[6]);
                    int shooting = int.Parse(cmdArgs[7]);

                    if (teams.ContainsKey(teamName))
                    {
                        try
                        {
                            teams[teamName]
                            .AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (action == "Remove")
                {
                    string teamName = cmdArgs[1];
                    string playerName = cmdArgs[2];

                    if (teams.ContainsKey(teamName))
                    {
                        try
                        {
                            teams[teamName].RemovePlayer(new Player(playerName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                    }
                }
                else
                {
                    string teamName = cmdArgs[1];

                    if (teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
