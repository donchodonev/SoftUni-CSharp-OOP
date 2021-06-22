using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Bus : Vehicle,IBus
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isAirConOn = true)
            : base(fuelQuantity, fuelConsumption, tankCapacity, isAirConOn)
        {
            if (isAirConOn)
            {
                FuelConsumptionModifier += 0.4;
            }
        }
        public string DriveEmpty(double distance)
        {
            isAirConditionOn = false;

            return base.Drive(distance);
        }
    }
}
