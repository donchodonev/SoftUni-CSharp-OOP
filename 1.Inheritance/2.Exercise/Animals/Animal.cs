using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            try
            {
                if (age < 0 
                    || string.IsNullOrEmpty(name)
                    || string.IsNullOrEmpty(gender))
                {
                    throw new Exception();
                }
                Name = name;
                Age = age;
                Gender = gender;
            }
            catch (Exception)
            {
                throw new Exception("Invalid input!");
            }
        }
        protected virtual string Type { get; private set; } = "Animal";
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public virtual string Sound { get; private set; } = "";
        public string ProduceSound()
        {
            return Sound;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Type);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append(Sound);
            return sb.ToString();
        }
    }
}