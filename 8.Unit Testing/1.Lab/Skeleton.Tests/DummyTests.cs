using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(10, 10);
    }

    [Test]
    public void AfterAttack_DummyLosesHealth()
    {
        dummy = new Dummy(20, 10);
        axe.Attack(dummy);
        Assert.That(dummy.Health,Is.EqualTo(10));
    }

    [Test]
    public void DeadDummy_ThrowsException_If_Attacked()
    {
        dummy = new Dummy(0, 10);
        Assert.That(() => dummy.TakeAttack(10),Throws.InvalidOperationException);
    }

    [Test]
    public void DeadDummy_CanGive_Experience()
    {
        dummy = new Dummy(0, 10);

        Assert.That(() => dummy.IsDead(), Is.True);
        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
    }

    [Test]
    public void AliveDummy_Cannot_GiveExperience()
    {
        dummy = new Dummy(10, 10);

        Assert.That(() => dummy.IsDead(), Is.False);

        Hero hero = new Hero("Doncho");

        hero.Attack(dummy);

        Assert.That(() => dummy.IsDead(), Is.True);

        Assert.That(hero.Experience, Is.EqualTo(10));
    }
}
