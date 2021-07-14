using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Skeleton.Interfaces
{
    public interface IWeapon
    {
        public int AttackPoints { get;}
        public int DurabilityPoints { get; }
        public void Attack(ITarget target);
    }
}
