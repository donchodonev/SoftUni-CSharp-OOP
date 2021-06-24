using System;

namespace _1._Square_Root
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}