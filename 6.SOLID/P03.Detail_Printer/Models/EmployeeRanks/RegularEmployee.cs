using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class RegularEmployee : IEmployee
    {
        public RegularEmployee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; }

        public decimal Salary { get; }
    }
}