using System;

namespace Facade
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarBuilderFacade carBuilder = new CarBuilderFacade()
                .Info
                .WithType("Audi")
                .WithColor("Black")
                .WithNumberOfDoors(2)
                .Built
                .InCity("Bavaria")
                .AtAddress("Ingolstadt");

            Car car = carBuilder.Build();

            Console.WriteLine(car);
        }
    }
}