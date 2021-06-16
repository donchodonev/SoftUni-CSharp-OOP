using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player : IEquatable<Player>
    {
        private string name;
        private int endurance;
        private int spring;
        private int dribble;
        private int passing;
        private int shooting;
        private int averageStats => endurance + spring + dribble + passing + shooting ;

        public Player(string name)
        {
            Name = name;
        }
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
            :this(name)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
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
        public int Endurance
        {
            private get => endurance;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            private get => spring;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                spring = value;
            }
        }
        public int Dribble
        {
            private get => dribble;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        public int Passing
        {
            private get => passing;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value;
            }
        }
        public int Shooting
        {
            private get => shooting;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                shooting = value;
            }
        }
        public int AverageStats
        {
            get => averageStats;
        }

        public bool Equals([AllowNull] Player other)
        {
            return Name == other.Name;
        }

        private bool IsStatValid(int value)
        {
            if (value < 0 || value > 100)
            {
                return false;
            }
            return true;
        }
    }
}
