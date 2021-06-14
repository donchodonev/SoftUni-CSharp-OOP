using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel)
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
