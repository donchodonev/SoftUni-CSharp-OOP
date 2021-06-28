using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        private ICollection<string> documents;

        public Manager(string name, decimal salary, ICollection<string> documents)
        {
            Documents = documents;
            Name = name;
            Salary = salary;
        }

        public ICollection<string> Documents
        {
            get { return documents; }
            private set { documents = value; }
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}