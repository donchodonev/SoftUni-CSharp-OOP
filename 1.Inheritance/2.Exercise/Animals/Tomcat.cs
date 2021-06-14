using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
             : base(name, age, GENDER)
        {

        }
        private const string GENDER = "Male";
        public override string Sound => "MEOW";
        protected override string Type => "Tomcat";

    }
}
