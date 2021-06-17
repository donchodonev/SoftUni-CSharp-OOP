using Military.Contracts;

namespace Military.Models
{
    public class Soldier : ISoldier
    {
        public Soldier()
        {
        }
        public Soldier(string iD, string firstName, string lastName)
            :this()
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}