using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Repair
    {
        public Repair(string part, double hoursWorked)
        {
            Part = part;
            HoursWorked = hoursWorked;
        }
        public string Part { get; set; }
        public double HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {Part} Hours Worked: {HoursWorked}";
        }
    }
}
