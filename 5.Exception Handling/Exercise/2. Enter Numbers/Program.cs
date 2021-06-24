using System;

namespace _2._Enter_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadNumber(int.Parse(Console.ReadLine()));
        }

        public static void ReadNumber(int number)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int n = number;

                    if (number < 1 || number > 100)
                    {
                        throw new ArgumentException();
                    }
                    number = int.Parse(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    i = 0;
                    number = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}