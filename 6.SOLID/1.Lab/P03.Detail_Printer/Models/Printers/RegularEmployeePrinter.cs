using P03.Detail_Printer.Interfaces;
using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models.Printers
{
    public class RegularEmployeePrinter : IPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            return employee is RegularEmployee;
        }

        public void Print(IEmployee employee)
        {
            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Salary);
        }
    }
}