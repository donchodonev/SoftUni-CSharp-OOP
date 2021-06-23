using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class WarriorFactory : HeroFactory
    {
        public WarriorFactory(string name) : base(name)
        {
        }
        public override BaseHero CreateHero()
        {
            return new Warrior(heroName);
        }
    }
}
