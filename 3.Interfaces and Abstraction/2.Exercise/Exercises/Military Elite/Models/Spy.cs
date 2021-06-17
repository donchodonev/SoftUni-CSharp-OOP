using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Spy:Soldier
    {
        public Spy()
        {
        }

        public Spy(string iD, string firstName, string lastName,int codeNumber)
            : base(iD, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID}");
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString();
        }
    }
}
