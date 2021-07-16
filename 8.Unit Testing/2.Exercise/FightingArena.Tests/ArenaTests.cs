using System.Collections.Generic;
using System.Linq;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;
        private int damage;
        private int health;
        [SetUp]
        public void Setup()
        {
            damage = 20;
            health = 50;

            arena = new Arena();

            attacker = new Warrior("Attacker", damage, health);
            defender = new Warrior("Defender", damage, health);
        }

        //Constructor test

        [Test]
        public void EmptyConstructor_Initialises_EmptyWarriorList()
        {
            //Arrange
            List<Warrior> expectedResult = new List<Warrior>();
            List<Warrior> actualResult = arena.Warriors.ToList();

            //Assert
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void WarriorsProperty_ShouldReturn_AddedWarriors()
        {
            //Arrange
            arena.Enroll(attacker);
            arena.Enroll(defender);

            //Act
            List<Warrior> expectedResult = new List<Warrior>()
            {
                attacker,
                defender
            };

            List<Warrior> actualResult = arena.Warriors.ToList();

            //Assert
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void WarriorsCountProperty_Should_Return_InnerWarriorList_Count()
        {
            //Arrange
            arena.Enroll(attacker);
            arena.Enroll(defender);

            //Act
            int expectedResult = arena.Warriors.Count;
            int actualResult = arena.Count;

            //Assert
            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}
