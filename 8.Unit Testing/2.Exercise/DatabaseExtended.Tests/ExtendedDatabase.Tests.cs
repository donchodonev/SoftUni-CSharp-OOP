using ExtendedDatabaseProject;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase exDatabase;
        private Person person;
        private Person[] personArray;

        [SetUp]
        public void Setup()
        {
            //Arrange
            long id = 1;
            string name = "Doncho";

            person = new Person(id, name);

            personArray = new Person[]
            {
                new Person(2, "Goshko"),
                new Person(3, "Dimitrichko")
            };

            exDatabase = new ExtendedDatabase();
        }

        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_Username()
        {
            //Act
            exDatabase.Add(person);
            
            //Assert
            Assert.That(() => exDatabase.Add(person),Throws.InvalidOperationException);
        }
    }
}