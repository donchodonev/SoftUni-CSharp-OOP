using System;
using CarManager;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private string make = "Audi";
        private string model = "A4";
        private double fuelConsumption = 10d;
        private double fuelCapacity = 100d;
        private double fuelAmount = 0; // int literal, as per Car class private constructor

        [SetUp]
        public void Setup()
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        //Constructor test

        [Test]
        public void Constructor_ShouldInstantiateObject_With_PassedValues()
        {
            //Assert
            Assert.Multiple(() =>
                {
                    Assert.AreEqual(car.Make, this.make);
                    Assert.AreEqual(car.Model, this.model);
                    Assert.AreEqual(car.FuelAmount, this.fuelAmount);
                    Assert.AreEqual(car.FuelCapacity, this.fuelCapacity);
                    Assert.AreEqual(car.FuelConsumption, this.fuelConsumption);
                }
            );
        }

        //Properties test
        //Setters
        //Testing only with constructor here as Car class is properly encapsulated and uses method DI

        [TestCase(null)]
        [TestCase("")]
        public void Make_Property_Setter_Should_ThrowException_When_Value_IsNullOrEmpty(string maker)
        {
            //Assert
            Assert.Throws
                <ArgumentException>(() => car = new Car(maker, this.model, this.fuelConsumption, this.fuelCapacity));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Model_Property_Setter_Should_ThrowException_When_Value_IsNullOrEmpty(string model)
        {
            //Assert
            Assert.Throws
                <ArgumentException>(() => car = new Car(this.make, model, this.fuelConsumption, this.fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumption_Property_Setter_Should_ThrowException_When_Value_IsLessOrEqualTo_Zero(double fuelConsumption)
        {
            //Assert
            Assert.Throws
                <ArgumentException>(() => car = new Car(this.make, this.model, fuelConsumption, this.fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacity_Property_Setter_Should_ThrowException_When_Value_IsLessOrEqualTo_Zero(double fuelCapacity)
        {
            //Assert
            Assert.Throws
                <ArgumentException>(() => car = new Car(this.make, this.model, this.fuelConsumption, fuelCapacity));
        }

        //Methods test
        //Refuel

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethod_Should_ThrowException_When_FuelAmount_Is_ZeroOrNegative(double fuelGiven)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelGiven));
        }

        [TestCase(100d)]
        [TestCase(1000d)]
        public void RefuelMethod_Should_Increment_FuelAmount_UpToFuel_MaxCapacity(double refuelAmount)
        {
            //Arrange
            double expectedFuelAmount = car.FuelCapacity;

            //Act
            car.Refuel(refuelAmount);
            double actualFuelAmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount,actualFuelAmount);
        }

        [Test]
        public void RefuelMethod_Should_Increment_FuelAmount()
        {
            //Arrange
            double expectedFuelAmount = 99d;
            double actualFuelAmount = car.FuelAmount;

            //Act
            car.Refuel(expectedFuelAmount);

            //Assert
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        //Methods test
        //Drive

        [Test]
        public void DriveMethod_ShouldThrowException_When_NotEnoughFuel()
        {
            //Arrange
            double distance = 1001;
            car.Refuel(100);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        public void DriveMethod_Should_Reduce_FuelAmount()
        {
            //Arrange
            double distance = 1000;
            double expectedFuelAmount = 0;

            //Act
            car.Refuel(100);
            car.Drive(distance);
            double actualFuelAmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount,actualFuelAmount);
        }
    }
}