using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;
        private string[] whitespacesEmptyAndNull;

        [SetUp]
        public void Setup()
        {
            //Arrange

            name = "Doncho";
            damage = 10;
            hp = 50;

            warrior = new Warrior(name, damage, hp);
        }

        //Constructor and getters test

        [Test]
        public void Constructor_Should_AssignValuesCorrectly_To_BackingField()
        {
            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(this.name, warrior.Name);
                Assert.AreEqual(this.damage, warrior.Damage);
                Assert.AreEqual(this.hp, warrior.HP);
            });
        }

        //Setters tests

        [Test]
        public void NameSetter_Should_ThrowException_When_NullOrWhitespace_IsPassed()
        {
            //Arrange
            whitespacesEmptyAndNull = new[] {"", "\n", "\r", "\t", "\f", "\v", null};

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[0], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[1], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[2], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[3], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[4], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[5], this.damage, this.hp));
                Assert.Throws<ArgumentException>(() => new Warrior(whitespacesEmptyAndNull[6], this.damage, this.hp));
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DamageSetter_Should_ThrowException_When_Damage_IsLessOrEqualTo_0(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(this.name, damage, this.hp));
        }

        [Test]
        public void HP_Setter_Should_ThrowException_When_Damage_IsLessOrEqualTo_0()
        {
            //Arrange
            int hp = -1;

            //Assert
            Assert.Throws<ArgumentException>(() => new Warrior(this.name, this.damage, hp));
        }

        //Methods test

        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethod_Should_ThrowException_When_AttackingWarrior_HP_IsUnderOrEqualTo_30(int hp)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior("Attacker", this.damage, hp);
            Warrior opposingWarrior = new Warrior("Opponent", this.damage, this.hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(opposingWarrior));
        }     
        
        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethod_Should_ThrowException_When_OpposingWarrior_HP_IsUnderOrEqualTo_30(int hp)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior("Attacker", this.damage, this.hp);
            Warrior opposingWarrior = new Warrior("Opponent", this.damage, hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(opposingWarrior));
        }

        [Test]
        public void AttackMethod_Should_ThrowException_When_OpponentDamage_IsGreater_ThanAttacker_Health()
        {
            //Arrange
            int damage = 51;
            Warrior opposingWarrior = new Warrior("Opponent", damage, this.hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(opposingWarrior));
        }
    }
}