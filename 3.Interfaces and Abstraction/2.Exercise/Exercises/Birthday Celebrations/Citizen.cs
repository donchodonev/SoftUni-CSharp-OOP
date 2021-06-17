using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Citizen : IIdentifiable,IBirthable,INameable
    {
        public Citizen(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }
            
        public Citizen(string name, int age, string iD,string birthdate) 
            : this(name, age, iD)
        {
            Birthdate = birthdate;
        }

        public int Age { get; private set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
    }
}
