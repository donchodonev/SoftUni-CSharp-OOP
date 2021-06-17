using Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Engineer : SpecialisedSoldier
    {
        public Engineer(string corp) 
            : base(corp)
        {
        }

        public Engineer
            (
            string iD, string firstName, string lastName,
            decimal salary, string corp , params string[] repairs
            )
            : base(iD, firstName, lastName,salary, corp)
        {
            Repairs = new List<Repair>();
            List<string> allRepairs = new List<string>(repairs);

            for (int i = 0; i < repairs.Length - 1; i+=2)
            {
                string part = repairs[i];
                int hours = int.Parse(repairs[i + 1]);

                Repairs.Add(new Repair(part,hours));
            }
        }
        private List<Repair> Repairs { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine($"Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString();
        }
    }
}
