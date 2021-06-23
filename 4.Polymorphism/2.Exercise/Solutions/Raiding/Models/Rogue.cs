using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;
        public Rogue(string name)
            : base(name)
        {
        }

        protected override string Name { get; set; }
        protected override int Power => ROGUE_POWER;
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
