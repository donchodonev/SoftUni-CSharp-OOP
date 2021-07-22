using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype_Pattern.AbstractSandwichPrototype
{
    public abstract class PrototypeSandwich
    {
        public abstract PrototypeSandwich Clone();
    }
}
