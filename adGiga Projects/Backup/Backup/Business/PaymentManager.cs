using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using ObjectCache;

namespace Business
{
    public class PaymentManager
    {

        public Payment GetPaymentByTransactionID(int transactionID)
        {
            return PaymentCache.GetInstance().GetPaymentByTransactionId(transactionID);
        }

        public void SyncPayment(Payment payment, DateTime paymentTime)
        {
            if (PaymentCache.GetInstance().GetPaymentByTransactionId(payment.Transaction.ID) == null)
            {
                //if payment not entered yet for this transaction, insert a new one
                PaymentCache.GetInstance().InsertPayment(payment, paymentTime);
            }
            else
            {
                payment.ID = PaymentCache.GetInstance().GetPaymentByTransactionId(payment.Transaction.ID).ID;
                PaymentCache.GetInstance().UpdatePayment(payment);
            }
        }

        internal double GetPaymentTotalByCustomerId(int customerID, DateTime startDate)
        {
            return PaymentCache.GetInstance().GetPaymentTotalByCustomerId(customerID, startDate);
        }

        internal double GetTotalPaymentForDay(DateTime day, bool bankMoney)
        {
            return PaymentCache.GetInstance().GetPaymentTotalForDay(day, bankMoney);
        }

        public List<Payment> GetPaymentsByCustomerId(int customerId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal void DeletePayment(int paymentId)
        {
            PaymentCache.GetInstance().DeletePayment(paymentId);
        }

        internal void RefreshCache()
        {
            PaymentCache.GetInstance().Clear();
            PaymentCache.GetInstance();
        }
    }
}
