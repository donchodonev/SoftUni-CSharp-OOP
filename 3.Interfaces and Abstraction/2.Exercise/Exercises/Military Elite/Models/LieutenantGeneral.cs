using Military.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military.Models
{
    public class LieutenantGeneral : Private
    {
        public LieutenantGeneral()
            :base()
        {
        }
        public LieutenantGeneral(string iD,string firstName,string lastName,decimal salary, List<Private> privatesUnderControl)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            PrivatesUnderControl = privatesUnderControl;
        }
        private List<Private> PrivatesUnderControl { get;set;}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:F2}");
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in PrivatesUnderControl)
            {
                sb.Append($"  {privateSoldier.ToString()}");
            }
            return sb.ToString();
        }
    }
}
