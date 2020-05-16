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
        /// <summary>
        /// Get payment made or received
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="startDate"></param>
        /// <param name="paymtMadeOrReceived">true for payment made, false for payment received</param>
        /// <returns></returns>
        internal double GetPaymentTotalByCustomerId(int customerID, DateTime startDate, bool paymtMadeOrReceived)
        {
            return PaymentCache.GetInstance().GetPaymentTotalByCustomerId(customerID, startDate, paymtMadeOrReceived);
        }

        /// <summary>
        /// Get total payment happened for day
        /// </summary>
        /// <param name="day"></param>
        /// <param name="bankMoney"></param>
        /// <param name="paymtMadeOrReceived">True if payment made, false if payment received</param>
        /// <returns></returns>
        internal double GetTotalPaymentForDay(DateTime day, bool bankMoney, bool paymtMadeOrReceived)
        {
            return PaymentCache.GetInstance().GetPaymentTotalForDay(day, bankMoney, paymtMadeOrReceived);
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
