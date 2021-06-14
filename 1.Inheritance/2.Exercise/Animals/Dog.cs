using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            :base(name, age, gender)
        {

        }
        public override string Sound => "Woof!";
        protected override string Type => "Dog";
    }
}
