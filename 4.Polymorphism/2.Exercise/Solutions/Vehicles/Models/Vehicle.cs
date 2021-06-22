using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        protected double FuelConsumption { get; set; }
        public abstract string Drive(double distance);
        public abstract void Refuel(double fuel);
    }
}
