using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Interfaces
{
    public interface IPrinter
    {
        public bool IsMatch(IEmployee employee);

        public void Print(IEmployee employee);
    }
}