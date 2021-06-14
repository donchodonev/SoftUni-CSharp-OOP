using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name
        {
            get => name;
            set { name = value; }
        }
        public IReadOnlyList<Person> FirstTeam
        {
            get => firstTeam.AsReadOnly();
        }
        public IReadOnlyList<Person> ReserveTeam
        {
            get => reserveTeam.AsReadOnly();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
