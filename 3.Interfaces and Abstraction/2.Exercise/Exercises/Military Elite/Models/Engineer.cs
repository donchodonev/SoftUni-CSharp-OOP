using Military.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary, corp)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => repairs;

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
