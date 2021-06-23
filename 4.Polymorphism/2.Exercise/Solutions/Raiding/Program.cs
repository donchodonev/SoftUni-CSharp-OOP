using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HeroFactory factory = null;

            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Paladin":
                        factory = new PaladinFactory(heroName);
                        break;
                    case "Druid":
                        factory = new DruidFactory(heroName);
                        break;
                    case "Rogue":
                        factory = new RogueFactory(heroName);
                        break;
                    case "Warrior":
                        factory = new WarriorFactory(heroName);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

                if (factory != null)
                {
                    heroes.Add(factory.CreateHero());
                    factory = null;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                raidPower += hero.GetPowerStat();
            }

            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
