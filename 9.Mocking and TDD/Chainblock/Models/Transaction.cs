using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        public Transaction()
        {

        }

        public Transaction(double amount, string @from, int id, TransactionStatus status, string to)
        : this()
        {
            Amount = amount;
            From = @from;
            Id = id;
            Status = status;
            To = to;
        }

        public double Amount { get; set; }
        public string From { get; set; }
        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string To { get; set; }
    }
}
