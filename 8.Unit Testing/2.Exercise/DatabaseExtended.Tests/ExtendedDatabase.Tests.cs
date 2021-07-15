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
            Assert.That(() => exDatabase.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_ID()
        {
            //Act
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void Should_ThrowException_IfRemovingUsers_WhenDatabase_IsEmpty()
        {
            //Assert
            Assert.That(() => exDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Should_ThrowException_WhenTryingToFind_UserWithName_EqualTo_Null()
        {
            //Act
            string username = null;

            //Assert
            Assert.That(() => exDatabase.FindByUsername(username), Throws.ArgumentNullException);
        }

        [Test]
        public void Should_ThrowException_WhenTryingToFind_UserWithName_EqualTo_EmptyString()
        {
            //Act
            string username = "";

            //Assert
            Assert.That(() => exDatabase.FindByUsername(username), Throws.ArgumentNullException);
        }

        [Test]
        public void Should_ThrowException_WhenTryingToFind_UserWithName_EqualTo_FalseUsername()
        {
            //Act
            string username = "non-existent-username";
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.FindByUsername(username),
                Throws.
                    InvalidOperationException.
                    With.
                    Message.
                    EqualTo("No user is present by this username!"));
        }
    }
}