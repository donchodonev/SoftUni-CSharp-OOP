using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Commando : SpecialisedSoldier
    {
        public Commando(string corp) 
            : base(corp)
        {
        }

        public Commando
            (
            string iD, string firstName, string lastName
            , decimal salary, string corp, params string[] missionParams
            )
            : base(iD, firstName, lastName, salary, corp)
        {
            Missions = new List<Mission>();
            List<string> allRepairs = new List<string>(missionParams);

            for (int i = 0; i < missionParams.Length - 1; i += 2)
            {
                string codename = missionParams[i];
                string state = missionParams[i + 1];

                try
                {
                    Missions.Add(new Mission(codename, state));
                }
                catch (Exception)
                {
                }
            }
        }
        private List<Mission> Missions{ get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString();
        }
        private void CompleteMission()
        {

        }
    }
}
