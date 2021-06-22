using System;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = null;
            Truck truck = null;
            Bus bus = null;

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleParams = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (vehicleParams[0])
                {
                    case "Car":
                        car =
                            new Car(
                            double.Parse(vehicleParams[1]),
                            double.Parse(vehicleParams[2]),
                            double.Parse(vehicleParams[3]));
                        break;
                    case "Truck":
                        truck =
                            new Truck(
                            double.Parse(vehicleParams[1]),
                            double.Parse(vehicleParams[2]),
                            double.Parse(vehicleParams[3]));
                        break;
                    case "Bus":
                        bus =
                            new Bus(
                            double.Parse(vehicleParams[1]),
                            double.Parse(vehicleParams[2]),
                            double.Parse(vehicleParams[3]));
                        break;
                    default:
                        break;
                }
            }

            //num of commands

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string driveOrRefuel = command[0];
                string vehicleType = command[1];
                double distanceOrLiters = double.Parse(command[2]);

                switch (driveOrRefuel)
                {
                    case "Drive":
                        switch (vehicleType)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(distanceOrLiters));
                                break;
                            case "Truck":
                                Console.WriteLine(truck.Drive(distanceOrLiters));
                                break;
                            case "Bus":
                                Console.WriteLine(bus.Drive(distanceOrLiters));
                                break;
                        }
                        break;
                        /////////
                    case "DriveEmpty":
                        switch (vehicleType)
                        {
                            case "Bus":
                                Console.WriteLine(bus.DriveEmpty(distanceOrLiters));
                                break;
                        }
                        break;
                        /////////
                    case "Refuel":
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Refuel(distanceOrLiters);
                                break;
                            case "Truck":
                                truck.Refuel(distanceOrLiters);
                                break;
                            case "Bus":
                                bus.Refuel(distanceOrLiters);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
