using System;

namespace _3._Fixing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("This loop is not right ;(");
                Console.WriteLine("It should instead look like this | int i = 0; i < 5; i++ |");
            }

            Console.ReadLine();
        }
    }
}