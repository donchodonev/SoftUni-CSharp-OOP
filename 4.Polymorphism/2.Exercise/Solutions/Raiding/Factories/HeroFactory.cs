using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class HeroFactory
    {
        protected string heroName = default;

        protected HeroFactory(string name)
        {
            heroName = name;
        }

        public abstract BaseHero CreateHero();
    }
}