using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public ITransaction this[int index]
        {
            get => transactions[index];
            set => transactions[index] = value;
        }

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

            return (IEnumerable<ITransaction>)transactionsToReturn;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return (IEnumerable<ITransaction>)transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            return transactions
                .Where(t => t.Status == status)
                .Select(t => t.From)
                .ToList();
        }

        public ITransaction GetById(int id)
        {
            if (!Contains(id))
            {
                throw new ArgumentException("Transaction with this ID doesn't exist");
            }

            return transactions.Single(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            int countOfTrForReceiver = transactions
                .Where(t => t.To == receiver)
                .Count();

            int countOfTrForReceiverInRange = transactions
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .Count();

            if (!ReceiverExists(receiver))
            {
                throw new InvalidOperationException("There are 0 transactions related to the receiver");
            }

            if (countOfTrForReceiverInRange == 0)
            {
                throw new InvalidOperationException("There are 0 transactions in the given range related to the receiver");
            }

            return transactions
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            int countOfTrForReceiver = transactions.Where(t => t.To == receiver)
                .Count();

            if (!ReceiverExists(receiver))
            {
                throw new InvalidOperationException("There are 0 transactions related to the receiver");
            }

            return transactions
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!SenderExists(sender))
            {
                throw new InvalidOperationException("Sender doesn't exist");
            }

            int transactionsAboveAmount = transactions.Where(t => t.Amount > amount)
                .Count();

            if (transactionsAboveAmount == 0)
            {
                throw new InvalidOperationException("Zero transactions above given amount found");
            }

            return transactions
                .Where(t => t.From == sender)
                .Where(t => t.Amount > amount)
                .OrderByDescending(t => t.Amount);
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

        public bool ReceiverExists(string receiver)
        {
            int countOfTrForReceiver = transactions
                .Where(t => t.To == receiver)
                .Count();

            if (countOfTrForReceiver > 0)
            {
                return true;
            }

            return false;
        }

        public bool SenderExists(string receiver)
        {
            int countOfTrForSender = transactions
                .Where(t => t.From == receiver)
                .Count();

            if (countOfTrForSender > 0)
            {
                return true;
            }

            return false;
        }
    }
}