using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;
        public Warrior(string name)
            : base(name)
        {
        }

        protected override string Name { get; set; }
        protected override int Power => WARRIOR_POWER;
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
