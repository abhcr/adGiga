using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using ObjectCache;

namespace Business
{
    public class SaleManager
    {
        public List<Sale> GetSalesByTransactionID(int transactionID)
        {
            return SaleCache.GetInstance().GetSalesByTransactionId(transactionID);
        }

        /// <summary>
        /// Inserts new, updates existing, and deletes missing purchases in the list provided for the particular transaction.
        /// </summary>
        /// <param name="purchases"></param>
        /// <param name="updateItem"></param>
        public void SyncSales(List<Sale> sales, bool updateItem, int transactionId)
        {
            //sync common child object, ie, transaction
            //each of them wil b having reference to same transaction. 
            //updating transaction of first purchase line will update everything.
            if (sales.Count > 0)
            {
                sales[0].Transaction = (new TransactionManager()).SyncTransaction(sales[0].Transaction);
            }
            for(int i=0; i<sales.Count;i++)
            {
                sales[i] = SyncSale(sales[i], updateItem, false);//transaction got synced already for all purchases. 
            }
            //clear removed purchases
            SaleCache.GetInstance().MarkRemovals(sales, transactionId);
        }
        /// <summary>
        /// Insert or update a given purchase
        /// </summary>
        /// <param name="purchase">Sale to be synchronized</param>
        /// <param name="updateItem">True for updating rate or unit or tax of an item. 
        /// False for not doing permanent update to item, but save vatiation in rate etc. for this purchase alone. </param>
        /// <param name="syncTransaction">False if transaction related to this purchase is synchronized already.
        /// True if need to be sychronized again, or if u r not sure what to pass.</param>
        /// <returns>Updated purchase</returns>
        public Sale SyncSale(Sale sale, bool updateItem, bool syncTransaction)
        {
            if (syncTransaction)
            {
                sale.Transaction = (new TransactionManager()).SyncTransaction(sale.Transaction);
            }
            //sync item
            sale.Item = (new ItemManager()).SyncItem(sale.Item, updateItem);
            sale.SaleUnit = (new UnitManager()).SyncUnit(sale.SaleUnit);
            return SaleCache.GetInstance().SyncSale(sale);
        }
        public List<SalesSummary> GetSalesSummary(DateTime startTime, DateTime endTime)
        {
            SalesSummary salesSummary;
            List<SalesSummary> salesSummaries = new List<SalesSummary>();
            //every sales will have a payment entry, even if zero payed. So look for payments
            List<Payment> paymentsForDay = PaymentCache.GetInstance().GetPaymentsByTime(startTime, endTime);
            foreach (Payment payment in paymentsForDay)
            {
                salesSummary = new SalesSummary();
                salesSummary.Payment = payment;
                salesSummaries.Add(salesSummary);
            }
            return salesSummaries;
        }

        public List<Sale> GetSalesByCustomerId(int customerId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeleteSale(int saleId)
        {
            SaleCache.GetInstance().DeleteSale(saleId);
        }

        internal void RefreshCache()
        {
            SaleCache.GetInstance().Clear();
            SaleCache.GetInstance();
        }
    }
}
