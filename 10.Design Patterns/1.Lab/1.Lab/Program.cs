using System;

namespace _1.Lab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SingletonDataContainer db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington, D.C."));
            SingletonDataContainer db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Washington, D.C."));
        }
    }
}