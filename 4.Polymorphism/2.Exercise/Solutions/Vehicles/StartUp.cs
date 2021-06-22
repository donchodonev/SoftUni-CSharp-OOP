using System;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car;
            Vehicle truck;

            //car setup

            string[] carParams = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]));

            //truck setup

            string[] truckParams = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]));

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
                        }
                        break;

                    case "Refuel":
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Refuel(distanceOrLiters);
                                break;
                            case "Truck":
                                truck.Refuel(distanceOrLiters);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
