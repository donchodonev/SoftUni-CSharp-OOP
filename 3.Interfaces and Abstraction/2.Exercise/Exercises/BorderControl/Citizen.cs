using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string iD)
        {
            Age = age;
            Name = name;
            ID = iD;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }
        public string ID { get; set; }
    }
}
