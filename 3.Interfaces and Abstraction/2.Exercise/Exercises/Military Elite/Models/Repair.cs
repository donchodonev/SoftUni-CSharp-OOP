using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Repair
    {
        public Repair(string part, int hoursWorked)
        {
            Part = part;
            HoursWorked = hoursWorked;
        }
        public string Part { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Part Name: {Part} Hours Worked: {HoursWorked}");
            return sb.ToString().Trim();
        }
    }
}
