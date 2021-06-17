using Military.Contracts;
using System.Text;

namespace Military.Models
{
    public class Private : Soldier
    {
        protected decimal Salary { get; set; }
        public Private()
            :base()
        {
        }
        public Private(string iD, string firstName, string lastName, decimal salary)
            :base(iD, firstName, lastName)
        {
            Salary = salary;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary}");
            return sb.ToString();
        }
    }
}
