using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Interfaces
{
    public interface IEmployee
    {
        public string Name { get; }
        public decimal Salary { get; }
    }
}