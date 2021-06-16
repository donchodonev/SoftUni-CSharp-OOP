using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace FootballTeamGenerator
{
    public class Team : IEquatable<Team>
    {

        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            Name = name;
        }

        private int rating => (int)Math.Round(Players.Average(p => p.AverageStats) / 5);
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        private List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public int Rating
        {
            get 
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return rating;
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            if (!Players.Contains(player))
            {
                Console.WriteLine($"Player {player.Name} is not in {Name} team.");
            }
            Players.Remove(player);
        }
        public bool Equals(Team other)
        {
            return Name == other.Name;
        }
    }
}
