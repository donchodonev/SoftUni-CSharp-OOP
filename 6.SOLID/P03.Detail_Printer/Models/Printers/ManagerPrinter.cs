using P03.Detail_Printer.Interfaces;
using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models.Printers
{
    public class ManagerPrinter : IPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            return employee is Manager;
        }

        public void Print(IEmployee employee)
        {
            Manager manager = employee as Manager;

            Console.WriteLine(manager.Name);
            Console.WriteLine(manager.Salary);
            Console.WriteLine("Documents info:");

            foreach (var document in manager.Documents)
            {
                Console.WriteLine($"  {document}");
            }
        }
    }
}