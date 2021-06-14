using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, GENDER)
        {

        }
        private const string GENDER = "Female";
        public override string Sound => "Meow";
        protected override string Type => "Kitten";

    }
}
