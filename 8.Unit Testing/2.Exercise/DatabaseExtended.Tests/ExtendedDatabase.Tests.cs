using System;
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

        //Count

        [Test]
        public void DatabaseCountProperty_Should_IncreaseBy1_ForEachPersonAdded()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //Act
            int expectedCount = 2;
            int actualCount = exDatabase.Count;

            //Act - Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        //Add method

        [Test]
        public void Should_ThrowException_WhenAddingUser_Exceeds_ArrayCapacity()
        {
            //Arrange
            int arraySize = 16;

            for (int i = 0; i < arraySize; i++)
            {
                exDatabase.Add(new Person(i, $"my name is {i}"));
            }
            //Assert
            Assert.That(() => exDatabase.Add(new Person(16,"Freud")),
                Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo("Array's capacity must be exactly 16 integers!"));
        }


        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_Username()
        {
            //Arrange
            Person secondPerson = new Person(999, person.UserName);

            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.Add(secondPerson),
                Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_ID()
        {
            //Arrange
            Person secondPerson = new Person(person.Id, "Gogi");

            //Act
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.Add(secondPerson),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethod_ShouldAddPerson_WhenAllConditionsAreMet()
        {
            //Arrange
            int expectedDatabasePeopleCount = 1;

            //Act
            exDatabase.Add(person);
            int actualDatabasePeopleCount = exDatabase.Count;

            //Assert
            Assert.AreEqual(expectedDatabasePeopleCount,actualDatabasePeopleCount);
        }

        //Remove() method

        [Test]
        public void RemoveMethod_Should_Work()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //Act
            exDatabase.Remove();
            int expectedCount = 1;
            int actualCount = exDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Should_ThrowException_IfRemovingUsers_WhenDatabase_IsEmpty()
        {
            //Arrange
            exDatabase = new ExtendedDatabase();

            //Assert
            Assert.That(() => exDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethod_ShouldRemove_Only_TheLastElement_InTheArray()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //Act
            Person removedPerson = new Person(3, "Dimitrichko");
            exDatabase.Remove(); //remove Dimitrichko

            //Assert
            Assert.That(() => exDatabase.FindById(removedPerson.Id), Throws.InvalidOperationException);
        }

        //FindByUsername() method

        [TestCase(null)]
        [TestCase("")]
        public void Should_ThrowException_WhenTryingToFind_UserWithName_EqualTo_NullOrEmpty(string username)
        {
            //Act
            exDatabase.Add(person);

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

        [Test]
        public void FindByUsername_ShouldBe_CaseSensitive()
        {
            //Arrange
            string newUsername = "doncho";

            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.FindByUsername(newUsername),
                Throws.
                    InvalidOperationException.
                    With.
                    Message.
                    EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsername_ShouldWork_With_CorrectUsername()
        {
            //Act
            exDatabase.Add(person);

            string expectedUsername = person.UserName;

            string actualUsername = exDatabase.FindByUsername(person.UserName).UserName;

            //Assert
            Assert.AreEqual(expectedUsername,actualUsername);
        }      
        
        //FindById() method 

        [Test]
        public void FindByID_ShouldWork_With_CorrectID()
        {
            //Arrange
            exDatabase.Add(person);

            //Act
            string expectedUserNameResult = "Doncho";
            string actualUserNameResult = exDatabase.FindById(person.Id).UserName;

            //Assert
            Assert.AreEqual(expectedUserNameResult,actualUserNameResult);
        }

        [Test]
        public void FindByID_WithNegativeValue_Should_ThrowException()
        {
            //Act
            long id = -1L;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => exDatabase.FindById(id));
        }

        [Test]
        public void FindByID_With_WrongID_Should_ThrowException()
        {
            //Assert
            exDatabase.Add(person);

            //Act
            long id = 111L;

            //Assert
            Assert.That(() => exDatabase.FindById(id),
                Throws
                    .InvalidOperationException
                    .With
                    .Message
                    .EqualTo("No user is present by this ID!"));
        }
    }
}