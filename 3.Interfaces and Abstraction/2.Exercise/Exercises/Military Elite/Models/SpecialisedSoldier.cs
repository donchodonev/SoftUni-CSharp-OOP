using Military.Contracts;
using System;

namespace Military.Models
{
    public class SpecialisedSoldier : Private
    {
        private string corp;
        public SpecialisedSoldier(string corp)
            :base()
        {
            Corp = corp;
        }
        public SpecialisedSoldier(string iD, string firstName, string lastName, decimal salary, string corp)
            : base(iD, firstName, lastName, salary)
        {
            Corp = corp;
            Salary = salary;
        }
        protected string Corp 
        {
            get => corp;
            set
            {
                if (value == "Marines")
                {
                    corp = value;
                }
                else if (value == "Airforces")
                {
                    corp = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
