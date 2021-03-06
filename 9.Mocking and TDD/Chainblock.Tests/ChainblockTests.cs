using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTrStatus_Should_ThrowException_When_IdNotContained()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(2, TransactionStatus.Aborted));
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
        public void GetAllOrderedByAmountDescending_Should_Return_AllAmountOrdererAccordingly()
        {
            //Arrange
            Mock<ITransaction> transaction;

            for (int i = 0; i < 5; i++)
            {
                transaction = new Mock<ITransaction>();

                transaction.SetupProperty(p => p.Amount);
                transaction.SetupProperty(p => p.Id);

                transaction.Object.Amount = i;
                transaction.Object.Id = i;

                chainblock.Add(transaction.Object);
            }

            //Act
            List<ITransaction> expectedTransactionsList = new List<ITransaction>();

            for (int i = 4; i >= 0; i--)
            {
                expectedTransactionsList.Add(chainblock.GetAllInAmountRange(0, 10)
                    .ToList()[i]);
            }

            //Assert
            Assert.AreEqual(expectedTransactionsList, chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetAllOrderedByAmountDescending_ThenById_Should_Return_AllTransactions_OrdererAccordingly()
        {
            //Arrange
            Mock<ITransaction> transaction;

            for (int i = 0; i < 5; i++)
            {
                transaction = new Mock<ITransaction>();

                transaction.SetupProperty(p => p.Amount);
                transaction.SetupProperty(p => p.Id);

                transaction.Object.Amount = 1;
                transaction.Object.Id = i;

                chainblock.Add(transaction.Object);
            }

            //Act
            List<ITransaction> expectedTransactionsList = new List<ITransaction>();

            for (int i = 0; i <= 4; i++)
            {
                expectedTransactionsList.Add(chainblock.GetAllInAmountRange(0, 10)
                    .ToList()[i]);
            }

            //Assert
            Assert.AreEqual(expectedTransactionsList, chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetAllReceiversByStatus_Should_Return_ReceiversName_By_Given_TrStatus()
        {
            //Arrange
            List<ITransaction> expectedReturn = new List<ITransaction>();

            for (int i = 0; i < 2; i++)
            {
                ITransaction transaction = new Transaction(15, "Suzi", i, TransactionStatus.Successfull, "Gogi");

                expectedReturn.Add(transaction);
                chainblock.Add(transaction);
            }

            ITransaction transactionWithDifferentStatus = new Transaction(15, "Suzi", 14, TransactionStatus.Aborted, "Pesho");

            expectedReturn.Add(transactionWithDifferentStatus);
            chainblock.Add(transactionWithDifferentStatus);

            IEnumerable<string> expectedResult = expectedReturn
                .Select(t => t.To)
                .ToList();

            IEnumerable<string> actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersByStatus_Should_Return_SenderName_By_Given_TrStatus()
        {
            //Arrange
            List<ITransaction> expectedReturn = new List<ITransaction>();

            for (int i = 0; i < 2; i++)
            {
                ITransaction transaction = new Transaction(15, "Gogi", i, TransactionStatus.Successfull, "Suzi");

                expectedReturn.Add(transaction);
                chainblock.Add(transaction);
            }

            ITransaction transactionWithDifferentStatus = new Transaction(15, "Pesho", 14, TransactionStatus.Aborted, "Suzi");

            expectedReturn.Add(transactionWithDifferentStatus);
            chainblock.Add(transactionWithDifferentStatus);

            IEnumerable<string> expectedResult = expectedReturn
                .Select(t => t.From)
                .ToList();

            IEnumerable<string> actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetById_ShouldReturn_Transaction_WithGivenID()
        {
            //Arrange
            mockTransaction.Setup(t => t.Id).Returns(1);

            //Act
            chainblock.Add(mockTransaction.Object);

            //Assert
            Assert.That(() => chainblock.GetById(1), Is.EqualTo(mockTransaction.Object));
        }

        [Test]
        public void GetById_Should_ThrowException_When_Transaction_IsMissing()
        {
            //Arrange
            mockTransaction.Setup(t => t.Id).Returns(1);

            //Act
            //chainblock.Add(mockTransaction.Object);

            //Assert
            Assert.That(() => chainblock.GetById(1), Throws.ArgumentException);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturn_CollectionOfTransactions_Between_GivenRanges()
        {
            //Arrange
            Transaction tr1 = new Transaction(4, "Gosho", 1, TransactionStatus.Successfull, "Pesho");
            Transaction tr2 = new Transaction(7, "Gosho", 2, TransactionStatus.Successfull, "Pesho");
            Transaction tr4 = new Transaction(7, "Gosho", 4, TransactionStatus.Successfull, "Pesho");
            Transaction tr3 = new Transaction(10, "Gosho", 3, TransactionStatus.Successfull, "Pesho");
            Transaction tr5 = new Transaction(10, "Gosho", 5, TransactionStatus.Successfull, "Sisi");

            //note the order
            chainblock.Add(tr2);
            chainblock.Add(tr4);
            chainblock.Add(tr1);
            chainblock.Add(tr3);

            string receiver = "Pesho";

            //Act
            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                //note the order
                tr2,tr4,tr1
            };

            List<ITransaction> actualResult = chainblock.GetByReceiverAndAmountRange(receiver, 4d, 8d)
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverAndAmountRange_Should_ThrowException_With_InvalidReceiver()
        {
            //Arrange
            mockTransaction.Setup(t => t.To).Returns("Georgi");
            chainblock.Add(mockTransaction.Object);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Pesho", 1, 10000));
        }

        [Test]
        public void GetByReceiverAndAmountRange_Should_ThrowException_With_ValidReceiver_But_InvalidRange()
        {
            //Arrange
            mockTransaction.Setup(t => t.To).Returns("Georgi");
            mockTransaction.Setup(t => t.Amount).Returns(15);
            chainblock.Add(mockTransaction.Object);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Georgi", 16, 10000));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturn_Transactions_ForName_Orderer()
        {
            //Arrange
            Transaction tr1 = new Transaction(1, "Gosho", 6, TransactionStatus.Successfull, "Shishi");
            Transaction tr2 = new Transaction(1, "Gosho", 4, TransactionStatus.Successfull, "Shishi");
            Transaction tr3 = new Transaction(3, "Gosho", 5, TransactionStatus.Successfull, "Shishi");

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);

            //Act
            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr3, tr2, tr1
            };

            List<ITransaction> actualResult = chainblock.GetByReceiverOrderedByAmountThenById("Shishi")
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_Should_ThrowException_ForInvalidReceiver()
        {
            //Arrange
            Transaction tr1 = new Transaction(1, "Gosho", 6, TransactionStatus.Successfull, "Shishi");
            chainblock.Add(tr1);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Goshko"));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnTransactions_Ordered()
        {
            //Arrange
            ITransaction tr1 = new Transaction(1, "Gosho", 1, TransactionStatus.Successfull, "Pesho");
            ITransaction tr2 = new Transaction(2, "Gosho", 2, TransactionStatus.Aborted, "Pesho");
            ITransaction tr3 = new Transaction(3, "Gosho", 3, TransactionStatus.Failed, "Pesho");

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);

            //Act
            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr3,tr2
            };

            List<ITransaction> actualResult = chainblock.GetBySenderAndMinimumAmountDescending("Gosho", 1)
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_Should_ThrowException_ForInvalidSender()
        {
            //Arrange
            ITransaction tr1 = new Transaction(5, "Gosho", 1, TransactionStatus.Successfull, "Pesho");

            //Act
            chainblock.Add(tr1);

            //Assert
            Assert
                .That(() => chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 1)
                    , Throws
                        .InvalidOperationException
                        .With
                        .Message
                        .EqualTo("Sender doesn't exist"));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_Should_ThrowException_ForInvalidAmount()
        {
            //Arrange
            ITransaction tr1 = new Transaction(5, "Gosho", 1, TransactionStatus.Successfull, "Pesho");

            //Act
            chainblock.Add(tr1);

            //Assert
            Assert
                .That(() => chainblock.GetBySenderAndMinimumAmountDescending("Gosho", 6)
                    , Throws
                        .InvalidOperationException
                        .With
                        .Message
                        .EqualTo("Zero transactions above given amount found"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_Should_ReturnTransactions_Orderer()
        {
            //Arrange
            ITransaction tr1 = new Transaction(1, "Gosho", 1, TransactionStatus.Successfull, "Pesho");
            ITransaction tr2 = new Transaction(2, "Gosho", 2, TransactionStatus.Aborted, "Atanas");
            ITransaction tr3 = new Transaction(3, "Gosho", 3, TransactionStatus.Failed, "Mikelanjelo");

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);

            //Act
            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr3, tr2, tr1
            };

            List<ITransaction> actualResult = chainblock.GetBySenderOrderedByAmountDescending("Gosho")
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_Should_ThrowException_ForNonExistingSender()
        {
            //Arrange
            ITransaction tr1 = new Transaction(1, "Gosho", 1, TransactionStatus.Successfull, "Pesho");

            //Act
            chainblock.Add(tr1);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Sasho"));
        }

        [Test]
        public void GetByTransactionStatus_Should_ReturnAccordingly()
        {
            //Arrange
            ITransaction tr1 = new Transaction(1, "Gosho", 1, TransactionStatus.Successfull, "Pesho");
            ITransaction tr2 = new Transaction(2, "Gosho", 2, TransactionStatus.Aborted, "Atanas");
            ITransaction tr3 = new Transaction(3, "Gosho", 3, TransactionStatus.Failed, "Mikelanjelo");

            //Act
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr1
            };

            List<ITransaction> actualResult = chainblock.GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatus_Should_ThrowException_ForMissingTr()
        {
            //Arrange
            ITransaction tr1 = new Transaction(1, "Gosho", 1, TransactionStatus.Successfull, "Pesho");
            ITransaction tr2 = new Transaction(2, "Gosho", 2, TransactionStatus.Aborted, "Atanas");

            //Act
            chainblock.Add(tr1);
            chainblock.Add(tr2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Should_ReturnCorrectTransactions()
        {
            //Arrange
            TransactionStatus ts = TransactionStatus.Successfull;

            ITransaction tr1 = new Transaction(13, "Gosho", 1, ts, "Pesho");
            ITransaction tr2 = new Transaction(22, "Gosho", 2, ts, "Atanas");
            ITransaction tr3 = new Transaction(33, "Gosho", 3, ts, "Mikelanjelo");
            ITransaction tr4 = new Transaction(15, "Gosho", 4, TransactionStatus.Aborted, "Mikelanjelo");

            //Act
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            List<ITransaction> expectedResult = new List<ITransaction>()
            {
                tr3,tr2, tr1
            };

            List<ITransaction> actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(ts, 33d)
                .ToList();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Should_ReturnEmptyCollection()
        {
            //Arrange
            TransactionStatus ts = TransactionStatus.Unauthorized;

            ITransaction tr1 = new Transaction(13, "Gosho", 1, ts, "Pesho");
            ITransaction tr2 = new Transaction(22, "Gosho", 2, ts, "Atanas");
            ITransaction tr3 = new Transaction(33, "Gosho", 3, ts, "Mikelanjelo");
            ITransaction tr4 = new Transaction(15, "Gosho", 4, TransactionStatus.Aborted, "Mikelanjelo");

            //Act
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            List<ITransaction> expectedResult = new List<ITransaction>();

            List<ITransaction> actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(ts, 50d)
                .ToList();
        }

        [Test]
        public void GetEnumerator_Should_Allow_CollectionToBeForEached()
        {
            //Arrange
            TransactionStatus ts = TransactionStatus.Unauthorized;

            ITransaction tr1 = new Transaction(13, "Gosho", 1, ts, "Pesho");
            ITransaction tr2 = new Transaction(22, "Gosho", 2, ts, "Atanas");
            ITransaction tr3 = new Transaction(33, "Gosho", 3, ts, "Mikelanjelo");
            ITransaction tr4 = new Transaction(15, "Gosho", 4, TransactionStatus.Aborted, "Mikelanjelo");

            //Act
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            Models.Chainblock newChainblock = new Models.Chainblock();

            foreach (var transaction in chainblock)
            {
                newChainblock.Add(transaction);
            }

            //Assert
            Assert.AreEqual(chainblock, newChainblock);
        }

        [Test]
        public void RemoveTrByID_Should_RemoveTr_FromChainblock()
        {
            //Act
            chainblock.Add(mockTransaction.Object);

            int countBeforeRemoval = chainblock.Count;

            //mockTransaction returns and ID of 1
            chainblock.RemoveTransactionById(1);

            int countAfterRemoval = chainblock.Count;

            //Assert
            Assert.AreNotEqual(countBeforeRemoval, countAfterRemoval);
        }

        [Test]
        public void RemoveTrByID_Should_ThrowException_ForNonExistingTrId()
        {
            //Act
            chainblock.Add(mockTransaction.Object);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(2));
        }
    }
}