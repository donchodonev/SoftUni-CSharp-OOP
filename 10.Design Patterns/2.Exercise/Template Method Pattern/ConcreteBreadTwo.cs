using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Method_Pattern
{
    public class ConcreteBreadTwo : AbstractBread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking concrete bread junior");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Mixing ingredients for concrete bread junior");
        }
    }
}
