using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using ObjectCache;
using System.Data;

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
            transaction.ParentProject = (new ProjectManager()).SyncProject(transaction.ParentProject);
            return TransactionCache.GetInstance().SyncTransaction(transaction);
        }

        internal int[] GetTransactionIdsByCustomerId(int customerID)
        {
            return TransactionCache.GetInstance().GetTransactionIdsByCustomerId(customerID);
        }

        internal double GetTransactionSumTotalByCustomerId(int customerID, DateTime startDate, bool purchase)
        {
            return TransactionCache.GetInstance().GetTransactionSumTotalByCustomerId(customerID, startDate, purchase);
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

        public void DeleteTransaction(int transactionId, bool updateStock)
        {
            SaleManager sm = new SaleManager();
            List<SalePurchase> sales = sm.GetSalesByTransactionID(transactionId);
            foreach (SalePurchase s in sales)
            {
                sm.DeleteSale(s.ID, updateStock);
            }
            sales.Clear();
            sm = null;

            PaymentManager pm = new PaymentManager();
            Payment p = pm.GetPaymentByTransactionID(transactionId);
            if (p == null)
            {
                p = new Payment();
                p.ID = -1;
            }
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
        /// <param name="updateStock">Mention if deleting a transaction should revert the changes in stock it made. Default is false</param>
        /// <returns>False if nothing to delete. True if deleted matching transactions.</returns>
        public bool DeleteAllTransactionsBefore(int customerId, DateTime purgeDate, bool keepOutstanding, bool updateStock=false)
        {
            purgeDate = purgeDate.Date;//set time to 0000hours of the date
            double outstanding = (new CustomerManager()).GetPendingAmountTill(customerId, purgeDate);
            List<Transaction> transactions = GetTransactionsByCustomerId(customerId);
            //remove all transactions before the given date
            List<Transaction> transactionsToDelete = transactions.FindAll(delegate(Transaction a)
            {
                if (a != null)
                {
                    return a.TransactionTime.Date < purgeDate;
                }
                else
                {
                    return false;
                }
            });
            if (transactionsToDelete.Count == 0)
            {
                return false;
            }
            //delete the filtered transactions...
            foreach (Transaction t in transactionsToDelete)
            {
                DeleteTransaction(t.ID, updateStock);
            }
            if (keepOutstanding)
            {
                //insert a new transaction with the outstanding amount, on one day before delete date
                Transaction t = new Transaction();
                t.ID = -1;
                t.Remark = "Outstanding Till " + purgeDate.Subtract(new TimeSpan(1, 0, 0, 0)).ToString("dd/MM/yyyy") + ".";
                t.Customer = new Customer();
                t.Customer.ID = customerId;
                t.TransactionTime = purgeDate.Date.Subtract(new TimeSpan(0, 0, 0, 1));
                t.TransactionSum = outstanding;
                t = (new TransactionManager()).SyncTransaction(t);
                //insert a negative payment with the outstanding amount.
                Payment p = new Payment();
                p.ID = -1;
                p.Amount = 0.0 - outstanding;
                p.BankMoney = false;
                p.Transaction = t;
                (new PaymentManager()).SyncPayment(p, t.TransactionTime);
            }
            return true;
        }

        public List<Transaction> GetTransactionsByItem(int itemId)
        {
            List<Transaction> transactionsWithGivenItem;
            try
            {
                transactionsWithGivenItem = TransactionCache.GetInstance().GetTransactionsByItem(itemId);
            }
            catch (Exception)
            {
                //in case of errors, return empty array of transactions
                transactionsWithGivenItem = new List<Transaction>();
            }
                //if (transactionsWithGivenItem.Count == 0)
            //{

            //}
            return transactionsWithGivenItem;
        }

        internal void RefreshCache()
        {
            TransactionCache.GetInstance().Clear();
            TransactionCache.GetInstance();
        }

        internal void ReplaceCustomer(int toBeReplacedID, int newID)
        {
            TransactionCache.GetInstance().ReplaceCustomer(toBeReplacedID, newID);
            //refresh cache content, if any
            TransactionCache.GetInstance().Clear();
        }

        internal List<Transaction> GetTransactionsByProjectId(int p)
        {
            return TransactionCache.GetInstance().GetTransactionsByProjectId(p);
        }
    }
}
