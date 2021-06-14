using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel)
            :base(horsePower,fuel)
        {

        }
        public override double FuelConsumption => DefaultFuelConsumption;
        public override void Drive(double kilometers)
        {
            double fuelAfterDriving = Fuel - (kilometers * FuelConsumption);

            if (fuelAfterDriving >= 0)
            {
                Fuel = fuelAfterDriving;
            }
        }
    }
}
