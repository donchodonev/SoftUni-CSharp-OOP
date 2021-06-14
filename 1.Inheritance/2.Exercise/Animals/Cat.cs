using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
             : base(name, age, gender)
        {

        }
        public override string Sound => "Meow meow";
        protected override string Type => "Cat";

    }
}
