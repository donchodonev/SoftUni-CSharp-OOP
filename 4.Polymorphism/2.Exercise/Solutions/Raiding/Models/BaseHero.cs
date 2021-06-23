using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }
        protected abstract string Name { get; set;}
        protected abstract int Power { get;}
        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name}";
        }
        public int GetPowerStat()
        {
            return Power;
        }
    }
}
