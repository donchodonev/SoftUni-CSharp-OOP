using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class DruidFactory : HeroFactory
    {
        public DruidFactory(string name)
            :base(name)
        {
        }
        public override BaseHero CreateHero()
        {
            return new Druid(heroName);
        }
    }
}
