using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
   public class Transaction : ITransaction
    {
        public double Amount { get; set; }
        public string From { get; set; }
        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string To { get; set; }
    }
}
