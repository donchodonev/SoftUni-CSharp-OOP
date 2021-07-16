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
        //Getters

        [Test]
        public void Make_Property_Getter_Should_Get_BackingField_Value()
        {
            //Act
            string expectedMake = this.make;
            string actualMake = car.Make;

            //Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void Model_Property_Getter_Should_Get_BackingField_Value()
        {
            //Act
            string expectedModel = this.model;
            string actualModel = car.Model;

            //Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void FuelConsumption_Property_Getter_Should_Get_BackingField_Value()
        {
            //Act
            double expectedFuelConsumption = this.fuelConsumption;
            double actualFuelConsumption = car.FuelConsumption;

            //Assert
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void FuelCapacity_Property_Getter_Should_Get_BackingField_Value()
        {
            //Act
            double expectedFuelCapacity = this.fuelCapacity;
            double actualFuelCapacity = car.FuelCapacity;

            //Assert
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void FuelAmount_Property_Getter_Should_Get_BackingField_Value()
        {
            //Act
            double expectedFuelAmount = this.fuelAmount;
            double actualFuelAmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
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

        [Test]
        public void RefuelMethod_Should_Increment_FuelAmount_ByFuelAmount_And_UpToFuel_MaxCapacity()
        {
            //Arrange
            double actualFuelAmount = 111d;

            //Act
            car.Refuel(actualFuelAmount);
            double expectedFuelAmount = car.FuelAmount;

            //Assert
            Assert.AreNotEqual(actualFuelAmount,expectedFuelAmount);
        }
    }
}