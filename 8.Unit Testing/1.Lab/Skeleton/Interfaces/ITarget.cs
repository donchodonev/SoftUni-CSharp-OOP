using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Interfaces
{
    public interface ITarget
    {
        public int Health { get; }
        public int GiveExperience();
        public void TakeAttack(int attackPoints);
        public bool IsDead();

    }
}
