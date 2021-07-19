using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Moq;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Mock<IChainblock> chainblock;
        private Mock<ITransaction> transaction;

        [SetUp]
        public void Initialise()
        {
            chainblock = new Mock<IChainblock>();
            transaction = new Mock<ITransaction>();
        }

        [Test]
        public void EmptyConstructor_Should_InitialiseObject()
        {
            Assert.IsNotNull(chainblock);
        }
    }
}
