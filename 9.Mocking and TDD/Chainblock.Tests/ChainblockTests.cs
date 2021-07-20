using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using Moq;
using Chainblock.Contracts;
using Chainblock;
using NUnit.Framework;
using Chainblock = Chainblock.Models.Chainblock;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Mock<IChainblock> mockChainblock;
        private Mock<ITransaction> mockTransaction;
        private Models.Chainblock chainblock;

        [SetUp]
        public void Initialise()
        {
            mockChainblock = new Mock<IChainblock>();
            mockTransaction = new Mock<ITransaction>();
            chainblock = new Models.Chainblock();
        }

        [Test]
        public void EmptyConstructor_Should_InitialiseObject()
        {
            Assert.IsNotNull(mockChainblock);
        }

        [Test]
        public void Count_ShouldIncrease_By_1_ForEachAddedTransaction()
        {
            //Arrange
            chainblock.Add(mockTransaction.Object);

            //Act
            int expectedCount = 1;
            int actualCount = chainblock.Count;

            //Assert
            Assert.AreEqual(expectedCount,actualCount);

        }

        [Test]
        public void Add_Should_AddTransaction_Successfully()
        {
            //Arrange
            chainblock.Add(mockTransaction.Object);

            //Act
            ITransaction expectedTransactionAt0Index = mockTransaction.Object;
            ITransaction actualTransaction = chainblock[0];

            //Assert
            Assert.AreEqual(expectedTransactionAt0Index,actualTransaction);
        }
        
        [Test]
        public void Add_Should_NotAddTransaction_Successfully_IfTransaction_IsNotUnique()
        {
            //Arrange
            mockTransaction.Setup(id => id.Id)
                .Returns(1);

            chainblock.Add(mockTransaction.Object);
            chainblock.Add(mockTransaction.Object);

            //Act
            int expectedTransactionsCount = 1;
            int actualTransactionCount = chainblock.Count;

            //Assert
            Assert.AreEqual(expectedTransactionsCount,actualTransactionCount);
        }

        [Test]
        public void ChangeTrStatus_Should_ChangeTrStatus_ForGiven_IdAndStatus()
        {
            Assert.Fail();

        }

        [Test]
        public void Contains_ShouldConfirm_Whether_GivenTransaction_IsFound_ByTransaction()
        {
            Assert.Fail();

        }

        [Test]
        public void Contains_ShouldConfirm_Whether_GivenTransaction_IsFound_ByID()
        {
            Assert.Fail();

        }

        [Test]
        public void GetAllAmountInRange_Should_Return_Transactions_BetweenRange()
        {
            Assert.Fail();

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_Should_Return_AllAmountOrdererAccordingly()
        {
            Assert.Fail();

        }

        [Test]
        public void GetAllReceiversByStatus_Should_Return_ReceiversName_By_Given_TrStatus()
        {
            Assert.Fail();

        }

        [Test]
        public void GetAllSendersByStatus_Should_Return_ReceiversName_By_Given_TrStatus()
        {
            Assert.Fail();
        }

        [Test]
        public void GetById_ShouldReturn_Transaction_WithGivenID()
        {
            Assert.Fail();
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturn_CollectionOfTransactions_Between_GivenRanges()
        {
            Assert.Fail();
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturn_Transactions_ForName_Orderer()
        {
            Assert.Fail();
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnTransactions_Ordered()
        {
            Assert.Fail();
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_Should_ReturnTransactions_Orderer()
        {
            Assert.Fail();
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Should_ReturnCorrectTransactions()
        {
            //returns all transactions with given status and amount less or
            //equal to a maximum allowed amount ordered by amount descending.
            //Returns an empty collection if no such transactions were found
            Assert.Fail();
        }

        [Test]
        public void GetEnumerator_Should_Allow_CollectionToBeForEached()
        {
            Assert.Fail();
        }
    }
}
