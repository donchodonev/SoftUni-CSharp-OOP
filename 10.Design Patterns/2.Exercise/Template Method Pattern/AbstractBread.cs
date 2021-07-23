using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Method_Pattern
{
    public abstract class AbstractBread
    {
        public abstract void Bake();

        public virtual void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }

        public abstract void MixIngredients();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing {this.GetType().Name}");
        }
    }
}
