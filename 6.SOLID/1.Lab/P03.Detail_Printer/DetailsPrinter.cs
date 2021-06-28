using P03.Detail_Printer.Interfaces;
using P03.Detail_Printer.Models.Printers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private List<IPrinter> printers;

        public DetailsPrinter()
        {
            printers = new List<IPrinter>()
            {
                new ManagerPrinter(),
                new RegularEmployeePrinter()
            };
        }

        public void Print(IEmployee employeeToPrint)
        {
            foreach (var printer in printers)
            {
                if (printer.IsMatch(employeeToPrint))
                {
                    printer.Print(employeeToPrint);
                }
            }
        }

        public void PrintMany(ICollection<IEmployee> employees)
        {
            foreach (var employee in employees)
            {
                foreach (var printer in printers)
                {
                    if (printer.IsMatch(employee))
                    {
                        printer.Print(employee);
                        break;
                    }
                }
            }
        }
    }
}