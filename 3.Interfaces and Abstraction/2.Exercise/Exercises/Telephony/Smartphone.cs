using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public void Browse(string site)
        {
            if (site.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {site}!");
            }
        }

        public void Call(string phone)
        {
            if (phone.All(char.IsDigit))
            {
                Console.WriteLine($"Calling... {phone}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
