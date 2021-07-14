using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Skeleton.Interfaces;

[TestFixture]
public class HeroTests
{
    private Hero hero;
    private IWeapon axe;
    private IWeapon fakeWeapon;
    private ITarget dummy;
    private ITarget fakeTarget;


    [SetUp]
    public void SetUp()
    {
        string heroName = "Doncho";

        hero = new Hero(heroName);

        int weaponAttackDamage = 10;
        int weaponDurability = 10;

        fakeWeapon = new FakeWeapon(weaponAttackDamage, weaponDurability);
        axe = new Axe(weaponAttackDamage, weaponDurability);

        int healthPoints = 10;
        int experience = 10;

        fakeTarget = new FakeTarget(healthPoints, experience);
        dummy= new Dummy(healthPoints, experience);
    }

    [Test]
    public void AssertThat_AfterAKill_ShouldGainExperience()
    {
        List<IWeapon> weapons = new List<IWeapon>();
        List<ITarget> targets = new List<ITarget>();

        //completely unnecessary but reflection is cool
        List<Type> weaponTypes = Assembly
            .GetAssembly(typeof(IWeapon))
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.Name == "IWeapon"))
            .ToList();

        List<Type> targetTypes = Assembly
            .GetAssembly(typeof(ITarget))
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.Name == "ITarget"))
            .ToList();

        foreach (var weaponType in weaponTypes)
        {
            weapons.Add((IWeapon)Activator.CreateInstance(weaponType,10,10));
        }

        foreach (var weapon in weapons)
        {
            hero.Weapon = weapon;

            foreach (var target in targets)
            {
                hero.Attack(target);
                Assert.That(hero.Experience,Is.EqualTo(20));
            }
        }
    }
}