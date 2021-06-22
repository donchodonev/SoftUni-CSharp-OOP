using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isAirConOn = true)
            : base(fuelQuantity, fuelConsumption, tankCapacity, isAirConOn)
        {
            if (isAirConOn)
            {
                FuelConsumptionModifier += 0.9;
            }
        }
    }
}
