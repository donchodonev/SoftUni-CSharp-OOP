using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PALADIN_POWER = 100;
        public Paladin(string name)
            : base(name)
        {
        }

        protected override string Name { get; set; }
        protected override int Power => PALADIN_POWER;
        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
