using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Expense
    {
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
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

        private ExpenseItem expenseItem;

        public ExpenseItem ExpenseItem
        {
            get { return expenseItem; }
            set { expenseItem = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
    }
}
