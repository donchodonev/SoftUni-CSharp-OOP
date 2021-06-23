using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class RogueFactory : HeroFactory
    {
        public RogueFactory(string name) 
            : base(name)
        {
        }

        public override BaseHero CreateHero()
        {
            return new Rogue(heroName);
        }
    }
}
