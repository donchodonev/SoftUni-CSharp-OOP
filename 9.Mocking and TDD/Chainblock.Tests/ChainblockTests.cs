using System;
using System.Collections;
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

            mockTransaction.Setup(id => id.Id)
                .Returns(1);
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
            Assert.AreEqual(expectedCount, actualCount);

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
            Assert.AreEqual(expectedTransactionAt0Index, actualTransaction);
        }

        [Test]
        public void Add_Should_NotAddTransaction_Successfully_IfTransaction_IsNotUnique()
        {

            chainblock.Add(mockTransaction.Object);
            chainblock.Add(mockTransaction.Object);

            //Act
            int expectedTransactionsCount = 1;
            int actualTransactionCount = chainblock.Count;

            //Assert
            Assert.AreEqual(expectedTransactionsCount, actualTransactionCount);
        }

        [Test]
        public void ChangeTrStatus_Should_ChangeTrStatus_ForGiven_IdAndStatus()
        {
            //Arrange
            mockTransaction.SetupProperty(p => p.Status);
            chainblock.Add(mockTransaction.Object);

            //Act
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull);

            TransactionStatus expectedStatus = TransactionStatus.Successfull;
            TransactionStatus actualStatus = chainblock[0].Status;

            //Assert
            Assert.AreEqual(expectedStatus,actualStatus);
        }

        [Test]
        public void Contains_ShouldConfirm_Whether_GivenTransaction_IsFound_ByTransaction()
        {
            //Arrange
            chainblock.Add(mockTransaction.Object);
            //Act
            bool expectedResult = true;
            bool actualResult = chainblock.Contains(mockTransaction.Object);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Contains_ShouldConfirm_Whether_GivenTransaction_IsFound_ByID()
        {
            //Arrange
            chainblock.Add(mockTransaction.Object);
            //Act
            int id = 1;
            bool expectedResult = true;
            bool actualResult = chainblock.Contains(id);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void GetAllAmountInRange_Should_Return_Transactions_BetweenRange()
        {
            //Arrange
            List<ITransaction> expectedTransactionsList = new List<ITransaction>();

            Mock<ITransaction> tr = new Mock<ITransaction>();

            for (int i = 0; i < 5; i++)
            {
                tr = new Mock<ITransaction>();

                tr.Setup(a => a.Id).Returns(i);
                tr.Setup(a => a.Amount).Returns(i);

                chainblock.Add(tr.Object);

                if (i >= 1 && i <= 3)
                {
                    expectedTransactionsList.Add(tr.Object);
                }
            }

            //Act
            IEnumerable<ITransaction> expectedTransactions = (IEnumerable<ITransaction>)expectedTransactionsList;
            IEnumerable<ITransaction> actualTransactions = chainblock.GetAllInAmountRange(1, 3);

            //Assert
            Assert.AreEqual(expectedTransactions, actualTransactions);
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
