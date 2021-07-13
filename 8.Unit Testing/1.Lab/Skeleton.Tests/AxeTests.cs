using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(10, 10);
        dummy = new Dummy(10, 10);
    }

    [Test]
    public void AxesLosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints,Is.EqualTo(9),"Axe durability doesn't change after attack.");
    }

    [Test]
    public void Axe_FailsToAttack_WhenBroken()
    {
        axe = new Axe(10, 0);
        Assert.That(() => axe.Attack(dummy),Throws.InvalidOperationException);
    }
}