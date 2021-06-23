using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class PaladinFactory : HeroFactory
    {
        public PaladinFactory(string name)
            : base(name)
        {
        }

        public override BaseHero CreateHero()
        {
            return new Paladin(heroName);
        }
    }
}
