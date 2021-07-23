using System;

namespace Template_Method_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractBread bread1 = new ConcreteBread();
            AbstractBread bread2 = new ConcreteBreadTwo();

            bread1.Make();
            bread2.Make();
        }
    }
}
