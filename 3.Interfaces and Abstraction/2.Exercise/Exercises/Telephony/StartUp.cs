using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split();
            string[] sites = Console.ReadLine()
                .Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
                else
                {
                    smartphone.Call(number);
                }
            }

            foreach (var site in sites)
            {
                smartphone.Browse(site);
            }
        }
    }
}
