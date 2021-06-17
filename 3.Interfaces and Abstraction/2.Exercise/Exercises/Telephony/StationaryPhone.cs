using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string phone)
        {
            if (phone.All(char.IsDigit))
            {
                Console.WriteLine($"Dialing... {phone}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
