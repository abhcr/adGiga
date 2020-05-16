using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DataObjects;

namespace ObjectCache
{
    public class PaymentCache
    {
        private PaymentCache()
        {

        }
        private static PaymentCache instance;
        public static PaymentCache GetInstance()
        {
            if (instance == null)
            {
                instance = new PaymentCache();
            }
            return instance;
        }


        public Payment GetPaymentByTransactionId(int transactionId)
        {
            double doubleVar;
            int intVar;
            Payment payment = null;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select P.ID, P.Amount, P.BankMoney From Payments As P Where P.TransactionId=?");
            command.Parameters.AddWithValue("Transaction", transactionId);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                payment = new Payment();
                if (int.TryParse(reader[0].ToString(), out intVar))
                {
                    payment.ID = intVar;
                }
                if (double.TryParse(reader[1].ToString(), out doubleVar))
                {
                    payment.Amount = doubleVar;
                }
                payment.BankMoney = bool.Parse(reader[2].ToString());
                reader.Close();
                payment.Transaction = TransactionCache.GetInstance().GetTransactionById(transactionId);
            }
            return payment;
        }

        public void InsertPayment(Payment payment, DateTime insertDateTime)
        {
            DateTime insertTime = insertDateTime;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Insert Into Payments (Amount, TransactionId, BankMoney, LastUpdatedTime) Values (?,?,?,?)");
            command.Parameters.AddWithValue("Amount", payment.Amount);
            command.Parameters.AddWithValue("Transaction", payment.Transaction.ID);
            command.Parameters.AddWithValue("BankMoney", payment.BankMoney);
            command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = insertTime;
            command.ExecuteNonQuery();
        }

        public void UpdatePayment(Payment payment)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Update Payments Set Amount=?, LastUpdatedTime=Now(), BankMoney=? Where ID=?");
            command.Parameters.AddWithValue("Amount", payment.Amount);
            command.Parameters.AddWithValue("BankMoney", payment.BankMoney);
            command.Parameters.AddWithValue("ID", payment.ID);
            //command.Parameters.AddWithValue("Transaction", payment.Transaction.ID);
            command.ExecuteNonQuery();

        }

        public double GetPaymentTotalByCustomerId(int customerID, DateTime startDate, bool purchase)
        {
            double total = 0;
            double doubleVar;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select P.Amount From Payments As P, Transactions As T, Customers As C " +
                "Where P.TransactionId=T.ID And T.Customer=C.ID And C.ID=? And T.TransactionTime>=? And T.SaleOrPurchase=" 
                + (purchase ? Properties.Settings.Default.PurchaseVar.ToString() : Properties.Settings.Default.SaleVar.ToString()));
            command.Parameters.AddWithValue("ID", customerID);
            command.Parameters.Add("TransactionTime", OleDbType.Date).Value = startDate.Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                if (double.TryParse(reader[0].ToString(), out doubleVar))
                {
                    total += doubleVar;
                }
            }
            return total;
        }

        public List<Payment> GetPaymentsByTime(DateTime startTime, DateTime endTime)
        {
            List<Payment> payments = new List<Payment>();
            Payment payment;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select P.ID, Amount, TransactionId From Payments As P, Transactions As T " +
                "Where P.TransactionId=T.ID And T.TransactionTime>=? And T.TransactionTime<?");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                payment = new Payment();
                payment.ID = int.Parse(reader[0].ToString());
                payment.Amount = double.Parse(reader[1].ToString());
                payment.Transaction = new Transaction();
                payment.Transaction.ID = int.Parse(reader[2].ToString());
                payments.Add(payment);
            }
            foreach (Payment p in payments)
            {
                p.Transaction = TransactionCache.GetInstance().GetTransactionById(p.Transaction.ID);
            }
            return payments;
        }
        /// <summary>
        /// Get Payment Total For Day
        /// </summary>
        /// <param name="day">Day of query</param>
        /// <param name="bankMoney">True for Bank Money, False for Hard Money</param>
        /// <param name="paymentMadeOrReceived">True if payment made, false if paymt received</param>
        /// <returns></returns>
        public double GetPaymentTotalForDay(DateTime day, bool bankMoney, bool paymentMadeOrReceived)
        {
            double total = 0.0;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select Sum(P.Amount) From Payments As P, Transactions As T " +
                "Where T.TransactionTime>=? And T.TransactionTime<? And T.ID=P.TransactionId And P.BankMoney=? And T.SaleOrPurchase=?");
            command.Parameters.Add("beginTime", OleDbType.Date).Value = day.Date;
            command.Parameters.Add("endTime", OleDbType.Date).Value = day.AddDays(1).Date;
            command.Parameters.AddWithValue("BankMoney", bankMoney);
            command.Parameters.AddWithValue("SaleOrPurchase", paymentMadeOrReceived ? Properties.Settings.Default.PurchaseVar: Properties.Settings.Default.SaleVar);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                double doubleVar = 0.0;
                if (double.TryParse(reader[0].ToString(), out doubleVar))
                {
                    total = doubleVar; // sale amount gets added to total.
                }
            }
            return total;
        }

        public void DeletePayment(int paymentId)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Delete From Payments Where ID=?");
            command.Parameters.AddWithValue("ID", paymentId);
            if(command.ExecuteNonQuery() > 1)
            {
                throw new ApplicationException("Error While Deleting Payment");
            }
        }
        public void Clear()
        {
            //nothing in cache to  clear
            instance = null;
        }
    }
}
