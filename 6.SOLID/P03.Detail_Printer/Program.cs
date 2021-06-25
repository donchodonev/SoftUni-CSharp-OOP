using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    internal class Program
    {
        private static void Main()
        {
            DetailsPrinter printer = new DetailsPrinter();

            RegularEmployee reg = new RegularEmployee("Bibi", 1999);
            Manager manager = new Manager("Dudi", 1999, new List<string>() { });
            manager.Documents.Add("Very important doc");
            manager.Documents.Add("Very important doc1");
            manager.Documents.Add("Very important doc2");
            manager.Documents.Add("Very important doc3");

            List<IEmployee> employees = new List<IEmployee>();

            employees.Add(reg);
            employees.Add(manager);

            printer.Print(reg);
            printer.Print(manager);

            Console.WriteLine("###########################");

            printer.PrintMany(employees);
        }
    }
}