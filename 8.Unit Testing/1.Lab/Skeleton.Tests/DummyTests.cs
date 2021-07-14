using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        int axeAttack = 10;
        int axeDurability = 10;

        axe = new Axe(axeAttack, axeDurability);
    }

    [Test]
    public void AfterAttack_DummyLosesHealth()
    {
        int initialDummyHealth = 20;
        int initialDummyExperience = 10;

        int healthLeftAfterAttack = 10;

        dummy = new Dummy(initialDummyHealth, initialDummyExperience);
        axe.Attack(dummy);
        Assert.That(dummy.Health,Is.EqualTo(healthLeftAfterAttack));
    }

    [Test]
    public void DeadDummy_ThrowsException_If_Attacked()
    {
        int initialDummyHealth = 0;
        int initialDummyExperience = 10;

        int attackDamage = 10;

        dummy = new Dummy(initialDummyHealth, initialDummyExperience);
        Assert.That(() => dummy.TakeAttack(attackDamage),Throws.InvalidOperationException);
    }

    [Test]
    public void DeadDummy_CanGive_Experience()
    {
        int initialDummyHealth = 0;
        int initialDummyExperience = 10;

        int expectedExperienceReturn = 10;

        dummy = new Dummy(initialDummyHealth, initialDummyExperience);

        Assert.That(() => dummy.IsDead(), Is.True);
        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(expectedExperienceReturn));
    }

    [Test]
    public void AliveDummy_Cannot_GiveExperience()
    {
        int initialDummyHealth = 10;
        int initialDummyExperience = 10;

        int expectedExperience = 10;
        string heroName = "Doncho";

        dummy = new Dummy(initialDummyHealth, initialDummyExperience);

        Assert.That(() => dummy.IsDead(), Is.False);

        Hero hero = new Hero(heroName);

        hero.Attack(dummy);

        Assert.That(() => dummy.IsDead(), Is.True);

        Assert.That(hero.Experience, Is.EqualTo(expectedExperience));
    }
}
