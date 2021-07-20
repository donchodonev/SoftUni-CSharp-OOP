using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                transactions.Add(tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Chainblock doesn't contain a transaction with ID {id}");
            }

            transactions.Single(t => t.Id == id).Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            int id = tx.Id;

            return Contains(id);
        }

        public bool Contains(int id)
        {
            return transactions.Any(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            List<ITransaction> transactionsToReturn = new List<ITransaction>();

            foreach (var transaction in this.transactions
                .Where(t => t.Amount >= lo)
                .Where(t => t.Amount <= hi))
            {
                transactionsToReturn.Add(transaction);
            }

            return (IEnumerable<ITransaction>) transactionsToReturn;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return (IEnumerable<ITransaction>) transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public ITransaction this[int index]
        {
            get => transactions[index];
            set => transactions[index] = value;
        }
    }
}
