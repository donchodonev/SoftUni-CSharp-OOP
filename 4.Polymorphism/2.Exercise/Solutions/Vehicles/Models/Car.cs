using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private double fuelConsModifier = 0.9; 
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override string Drive(double distance)
        {
            if ((FuelConsumption + fuelConsModifier) * distance < FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption + fuelConsModifier) * distance;
                return $"Car travelled {distance} km";
            }
            return "Car needs refueling";
        }
        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
