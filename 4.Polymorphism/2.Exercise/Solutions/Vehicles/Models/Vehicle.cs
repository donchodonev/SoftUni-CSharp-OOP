using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle
            (
            double fuelQuantity,
            double fuelConsumption,
            double tankCapacity,
            bool isAirConOn = true
            )
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            isAirConditionOn = isAirConOn;
            TankCapacity = tankCapacity;

            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0.0;
            }
            //default set values

            RefuelModifier = 1D;
            FuelConsumptionModifier = 1D;
        }
        private double tankCapacity;
        private double fuelConsumption;

        public double FuelQuantity { get; set; }
        protected bool isAirConditionOn { get; set; }
        protected double FuelConsumption
        {
            get 
            {
                if (isAirConditionOn)
                {
                    return fuelConsumption + FuelConsumptionModifier;
                }
                return fuelConsumption;
            }

            set { fuelConsumption = value; }
        }


        protected double TankCapacity
        {
            get => tankCapacity;
            set 
            { 
                tankCapacity = value;
            }
        }


        //modifiers
        protected double RefuelModifier { get; set; }
        protected double FuelConsumptionModifier { get; set; }

        //methods

        public virtual string Drive(double distance)
        {
            if (FuelConsumption * distance < FuelQuantity)
            {
                FuelQuantity -= FuelConsumption * distance;
                isAirConditionOn = true;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            isAirConditionOn = true;
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel * RefuelModifier > tankCapacity - FuelQuantity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else if (fuel <= 0.0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                FuelQuantity += fuel * RefuelModifier;
            }
        }
    }
}
