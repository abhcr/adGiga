using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Transaction
    {
        public Transaction()
        {
            id = -1;
            transactionTime = DateTime.Now;
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime transactionTime;

        public DateTime TransactionTime
        {
            get { return transactionTime; }
            set { transactionTime = value; }
        }
        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private double transactionSum;

        public double TransactionSum
        {
            get { return transactionSum; }
            set { transactionSum = value; }
        }

    }
}
