using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;
        public Druid(string name)
            : base(name)
        {
        }

        protected override string Name { get; set; }
        protected override int Power => DRUID_POWER;
        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
