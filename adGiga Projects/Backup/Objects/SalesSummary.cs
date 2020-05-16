using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class SalesSummary
    {

        private Payment payment;
        public Payment Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public string SaleTime
        {
            get { return payment.Transaction.TransactionTime.ToString("hh:mm:ss tt"); }
        }

        public int SaleNumber
        {
            get { return payment.Transaction.ID; }
        }
        public string CustomerName
        {
            get { return payment.Transaction.Customer.Name; }
        }
        public double SaleTotal
        {
            get { return payment.Transaction.TransactionSum; }
        }
        public double PaymentTotal
        {
            get { return payment.Amount; }
        }
    }
}
