using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Payment
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private Transaction transaction;

        public Transaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public bool BankMoney { get; set; }
    }
}
