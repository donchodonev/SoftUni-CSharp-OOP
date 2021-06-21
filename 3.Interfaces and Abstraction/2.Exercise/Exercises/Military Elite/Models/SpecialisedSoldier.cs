using Military_Elite.Contracts;
using System;

namespace Military.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corp)
            : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public string Corp
        {
            get => corp;

            set
            {
                if (value == "Marines" || value == "Airforces")
                {
                    corp = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corp}";
        }
    }
}
