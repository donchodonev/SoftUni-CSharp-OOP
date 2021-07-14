using System;
using Skeleton.Interfaces;

public class FakeTarget : ITarget
{
    private int health;
    private int experience;

    public FakeTarget(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    public int Health 
    {
        get { return this.health; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("FakeTarget is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("FakeTarget is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}
