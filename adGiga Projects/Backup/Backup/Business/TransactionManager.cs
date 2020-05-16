using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using ObjectCache;

namespace Business
{
    public class TransactionManager
    {
        public Transaction GetTransactionByID(int transactionID)
        {
            return TransactionCache.GetInstance().GetTransactionById(transactionID);
        }

        public Transaction SyncTransaction(Transaction transaction)
        {
            return TransactionCache.GetInstance().SyncTransaction(transaction);
        }

        internal int[] GetTransactionIdsByCustomerId(int customerID)
        {
            return TransactionCache.GetInstance().GetTransactionIdsByCustomerId(customerID);
        }

        internal double GetTransactionSumTotalByCustomerId(int customerID, DateTime startDate)
        {
            return TransactionCache.GetInstance().GetTransactionSumTotalByCustomerId(customerID, startDate);
        }

        public List<Transaction> GetTransactionsByCustomerId(int customerId)
        {
            int[] transIds = GetTransactionIdsByCustomerId(customerId);
            List<Transaction> transactions = new List<Transaction>();
            if (transIds != null)
            {
                for (int i = 0; i < transIds.Length; i++)
                {
                    transactions.Add(GetTransactionByID(transIds[i]));
                }
            }
            return transactions;
        }

        public void DeleteTransaction(int transactionId)
        {
            SaleManager sm = new SaleManager();
            List<Sale> sales = sm.GetSalesByTransactionID(transactionId);
            foreach (Sale s in sales)
            {
                sm.DeleteSale(s.ID);
            }
            sales.Clear();
            sm = null;

            PaymentManager pm = new PaymentManager();
            Payment p = pm.GetPaymentByTransactionID(transactionId);
            pm.DeletePayment(p.ID);
            p = null;
            pm = null;

            TransactionCache.GetInstance().DeleteTransaction(transactionId);
        }
        /// <summary>
        /// Delete all transactions before the selected date
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="purgeDate">date before which transactions will be deleted</param>
        /// <param name="keepOutstanding">Insert a new transaction with the outstanding amount till selected date</param>
        /// <returns>False if nothing to delete. True if deleted matching transactions.</returns>
        public bool DeleteAllTransactionsBefore(int customerId, DateTime purgeDate, bool keepOutstanding)
        {
            double outstanding = (new CustomerManager()).GetPendingAmountTill(customerId, purgeDate);
            List<Transaction> transactions = GetTransactionsByCustomerId(customerId);
            //remove all transactions on and after the given date
            List<Transaction> transactionsToDelete = transactions.FindAll(delegate(Transaction a)
            {
                return a.TransactionTime.Date < purgeDate;
            });
            if (transactionsToDelete.Count == 0)
            {
                return false;
            }
            //delete the filtered transactions...
            foreach (Transaction t in transactionsToDelete)
            {
                DeleteTransaction(t.ID);
            }
            if (keepOutstanding)
            {
                //insert a new transaction with the outstanding amount, on one day before delete date
                Transaction t = new Transaction();
                t.ID = -1;
                t.Remark = "Outstanding Till " + purgeDate.Subtract(new TimeSpan(1, 0, 0, 0)).ToShortDateString() + ".";
                t.Customer = new Customer();
                t.Customer.ID = customerId;
                t.TransactionTime = purgeDate.Subtract(new TimeSpan(1, 0, 0, 0));
                t.TransactionSum = outstanding;
                t = (new TransactionManager()).SyncTransaction(t);
                //insert a negative payment with the outstanding amount.
                Payment p = new Payment();
                p.ID = -1;
                p.Amount = 0.0 - outstanding;
                p.BankMoney = false;
                p.Transaction = t;
                (new PaymentManager()).SyncPayment(p, purgeDate.Subtract(new TimeSpan(1, 0, 0, 0)));
            }
            return true;
        }

        internal void RefreshCache()
        {
            TransactionCache.GetInstance().Clear();
            TransactionCache.GetInstance();
        }
    }
}
