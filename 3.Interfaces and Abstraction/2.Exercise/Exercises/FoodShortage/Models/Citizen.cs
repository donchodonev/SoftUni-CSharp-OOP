using FoodShortage.Contracts;

namespace FoodShortage
{
    public class Citizen : IIdentifiable,IBirthable,IAging,IBuyer
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

        public int Age { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
