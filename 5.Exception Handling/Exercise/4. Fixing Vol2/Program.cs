using System;

namespace _4._Fixing_Vol2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int num1, num2;
            byte result = 0;
            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result variable type must be at least of type Int32");
                return;
            }

            Console.ReadLine();
        }
    }
}