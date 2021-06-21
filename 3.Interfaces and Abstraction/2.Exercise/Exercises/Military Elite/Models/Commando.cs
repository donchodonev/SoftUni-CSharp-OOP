using Military.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            missions = new List<Mission>();
        }

        public IReadOnlyCollection<IMission> Missions => missions;

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
