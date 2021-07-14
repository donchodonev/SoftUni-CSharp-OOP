using DatabaseProject;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            //Arrange
            database = new Database();
        }

        [Test]
        public void EmptyConstructorInit_ShouldReturn_ZeroElementsCount()
        {
            //Act
            int actualCount = database.Count;
            int expectedCount = 0;

            //Assert
            Assert.That(actualCount,Is.EqualTo(expectedCount));
        }

        [Test]
        public void ConstructorWithTwoElements_ShouldReturn_TwoElementsCount()
        {
            //Arrange
            int[] twoElements = new int[] { 1, 2 };
            database = new Database(twoElements);

            //Act
            int actualCount = database.Count;
            int expectedCount = 2;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void WhenArraySizeLargerThan16_Should_ThrowException()
        {
            //Arrange
            int oneMoreNumber = 1;
            int arraySize = 16;

            database = new Database(new int[arraySize]);

            //Assert
            Assert.That(() => database.Add(oneMoreNumber),Throws.InvalidOperationException);
        }

        [Test]
        public void LastIndex_ShouldEqual_PreviousElementIndex_Plus_1()
        {
            //Arrange
            int number = 1;

            //Act
            database.Add(number); 
            database.Add(number);

            //// indices = [0] and [1]
            //// Count = 2
            //// current element index is at |database.Count - 1|

            int previousElementIndex = database.Count - 2;

            int expectedIndex = 0;

            //Assert
            Assert.That(previousElementIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void RemovingElement_FromEmptyDatabase_Should_ThrowException()
        {
            //Assert
            Assert.That(() => database.Remove(),
                Throws.
                    InvalidOperationException.
                    With.
                    Message.
                    EqualTo("The collection is empty!"));
        }

        [Test]
        public void RemoveMethod_ShouldRemove_Only_TheLastElement_InTheArray()
        {
            //Arrange
            int[] numArray = new int[] {0, 1, 2, 3, 4, 5};
            database = new Database(numArray);

            //Act
            database.Remove();
            int expectedValueAtLastIndex = 4;
            int actualValueAtLastIndex = database.Fetch()[database.Count - 1];

            //Assert
            Assert.That(expectedValueAtLastIndex,Is.EqualTo(actualValueAtLastIndex));
        }
    }
}