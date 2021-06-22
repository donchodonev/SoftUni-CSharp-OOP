using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double fuelConsModifier = 1.6;
        private double refuelModifier = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if ((FuelConsumption + fuelConsModifier) * distance < FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption + fuelConsModifier) * distance;
                return $"Truck travelled {distance} km";
            }
            return "Truck needs refueling";
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel * refuelModifier;
        }
    }
}
