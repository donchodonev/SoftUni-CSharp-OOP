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
        public void DatabaseCountProperty_Should_IncreaseBy1_ForEachPersonAdded()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            int expectedCount = 2;
            int exDatabaseCount = exDatabase.Count;

            //Act - Assert
            Assert.AreEqual(expectedCount, exDatabaseCount);
        }

        [Test]
        public void EmptyConstructorInit_ShouldReturn_ZeroElementsCount()
        {
            //Act
            int actualCount = exDatabase.Count;
            int expectedCount = 0;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ConstructorWithTwoElements_ShouldReturn_TwoElementsCount()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //Act
            int actualCount = exDatabase.Count;
            int expectedCount = 2;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void WhenArraySizeLargerThan16_Should_ThrowException()
        {
            //Arrange
            int arraySize = 16;

            for (int i = 0; i < arraySize; i++)
            {
                exDatabase.Add(new Person(i, $"my name is {i}"));
            }
            //Assert
            Assert.That(() => exDatabase.Add(person), 
                Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void LastIndex_ShouldEqual_PreviousElementIndex_Plus_1()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //// indices = [0] and [1]
            //// Count = 2
            //// current element index is at |database.Count - 1|

            int previousElementIndex = exDatabase.Count - 2;

            int expectedIndex = 0;

            //Assert
            Assert.That(previousElementIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_Username()
        {
            //Act
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.Add(person),
                Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Should_ThrowException_IfAdding_UserWithExisting_ID()
        {
            //Assert
            Person secondPerson = new Person(person.Id, "Gogi");

            //Act
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.Add(secondPerson),
                Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo("There is already user with this Id!"));
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

        [Test]
        public void Should_ThrowException_IfRemovingUsers_WhenDatabase_IsEmpty()
        {
            //Arrange
            exDatabase = new ExtendedDatabase();

            //Assert
            Assert.That(() => exDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethod_Should_Work()
        {
            //Arrange
            exDatabase = new ExtendedDatabase(personArray);

            //Act
            exDatabase.Remove();
            int expectedCount = 1;
            int actualCount = exDatabase.Count;

            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void RemoveMethod_ShouldRemove_Only_TheLastElement_InTheArray()
        {
            //Arrange
            exDatabase.Add(person);
            int lastIndex = exDatabase.Count - 1;

            //Act
            exDatabase.Remove();

            int expectedLastIndex = 0;

            //Assert
            Assert.That(lastIndex, Is.EqualTo(expectedLastIndex));
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
            string username = string.Empty;

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
            //Act
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
            //Assert
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.FindByUsername(person.UserName),Is.EqualTo(person));
        }      
        
        [Test]
        public void FindByID_ShouldWork_With_CorrectID()
        {
            //Assert
            exDatabase.Add(person);

            //Assert
            Assert.That(() => exDatabase.FindById(person.Id),Is.EqualTo(person));
        }

        [Test]
        public void FindByID_WithNegativeValue_Should_ThrowException()
        {
            //Act
            long id = -1;

            //Assert
            Assert.That(() => exDatabase.FindById(id),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByID_With_WrongID_Should_ThrowException()
        {
            //Assert
            exDatabase.Add(person);

            //Act
            long id = 111;

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