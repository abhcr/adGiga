using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;

namespace ObjectCache
{
    public class TransactionCache
    {
        private static TransactionCache instance;
        private TransactionCache()
        {
            
        }
        public static TransactionCache GetInstance()
        {
            if (instance == null)
            {
                instance = new TransactionCache();
            }
            return instance;
        }

        public Transaction SyncTransaction(Transaction transaction)
        {
            if (transaction.ID < 0)
            {   //insert
                DBFunctions.GetInstance().OpenConnection();
                DateTime updatedTime = DateTime.Now;
                OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Transactions " +
                    "(TransactionTime, Customer, Remarks, TransactionSum, LastUpdatedTime) Values (?,?,?,?,?)");
                command.Parameters.Add("TransactionTime", OleDbType.Date).Value = transaction.TransactionTime;
                command.Parameters.AddWithValue("Customer", transaction.Customer.ID);
                command.Parameters.AddWithValue("Remarks", transaction.Remark);
                command.Parameters.AddWithValue("TransactionSum", transaction.TransactionSum);
                command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = updatedTime;
                command.ExecuteNonQuery();
                //get back the id
                command = DBFunctions.GetInstance().GetCommand("Select ID From Transactions Where LastUpdatedTime = ?");
                command.Parameters.Clear();
                command.Parameters.Add("TransactionTime", OleDbType.Date).Value = updatedTime;
                OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
                if (reader.Read())
                {
                    transaction.ID = int.Parse(reader[0].ToString());
                }
            }
            else
            {
                //update
                DBFunctions.GetInstance().OpenConnection();
                ////update only the date part
                //transaction.TransactionTime 
                //    = DateTime.Parse(insertTime.ToString("MMMM/dd/yyyy ") + transaction.TransactionTime.ToString("hh:mm:ss tt"));
                OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Transactions " +
                    "Set Customer=?, Remarks=?, TransactionSum=?, LastUpdatedTime=Now(), TransactionTime=? Where ID=?");
                command.Parameters.AddWithValue("Customer", transaction.Customer.ID);
                command.Parameters.AddWithValue("Remarks", transaction.Remark);
                command.Parameters.AddWithValue("TransactionSum", transaction.TransactionSum);
                command.Parameters.Add("TransactionTime", OleDbType.Date).Value = 
                    transaction.TransactionTime;
                command.Parameters.AddWithValue("ID", transaction.ID);
                command.ExecuteNonQuery();
            }
            return transaction;
        }

        public Transaction GetTransactionById(int transactionID)
        {
            DateTime timeVar;
            int intVar;
            double doubleVar;
            Transaction tx = new Transaction();
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select TransactionTime, Customer, Remarks, TransactionSum From Transactions " +
                "Where ID=?");
            command.Parameters.Clear();
            command.Parameters.AddWithValue("ID", transactionID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                tx.ID = transactionID;
                if (DateTime.TryParse(reader[0].ToString(), out timeVar))
                {
                    tx.TransactionTime = timeVar;
                }
                if (int.TryParse(reader[1].ToString(), out intVar))
                {
                    tx.Customer = new Customer();
                    tx.Customer.ID = intVar;
                }
                tx.Remark = reader[2].ToString();

                if (double.TryParse(reader[3].ToString(), out doubleVar))
                {
                    tx.TransactionSum = doubleVar;
                }
                tx.Customer = CustomerCache.GetInstance().GetCustomerById(tx.Customer.ID);
                return tx;
            }
            else
                return null;
        }

        public int[] GetTransactionIdsByCustomerId(int customerID)
        {
            int intVar;
            List<int> transactionIds = new List<int>();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select T.ID From Transactions As T, Customers As C Where T.Customer=C.ID And C.ID=?");
            command.Parameters.AddWithValue("ID", customerID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                if (int.TryParse(reader[0].ToString(), out intVar))
                {
                    transactionIds.Add(intVar);
                }
            }
            if (transactionIds.Count > 0)
            {
                return transactionIds.ToArray();
            }
            else
            {
                return null;
            }
        }

        public double GetTransactionSumTotalByCustomerId(int customerID, DateTime startDate)
        {
            double sumTotal = 0;
            double doubleVar;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                //"Select Sum(T.TransactionSum) From Transactions As T Where T.Customer=?");
                "Select Sum(S.SaleQuantity*S.SaleRate) From Sales As S, Transactions As T "+
                "Where T.Customer=? And S.TransactionId=T.ID And T.TransactionTime>=?");
            command.Parameters.AddWithValue("ID", customerID);
            command.Parameters.Add("TransactionTime", OleDbType.Date).Value = startDate.Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if(reader.Read())
            {
                if (double.TryParse(reader[0].ToString(), out doubleVar))
                {
                    sumTotal = doubleVar;
                }
            }
            return sumTotal;
        }

        public void GetTransactionIdsByDate(DateTime dateTime)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeleteTransaction(int transactionId)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Delete From Transactions Where ID=?");
            command.Parameters.AddWithValue("ID", transactionId);
            if (command.ExecuteNonQuery() > 1)
            {
                throw new Exception("Error while deleting transaction. Tx ID:" + transactionId);
            }
        }

        public void Clear()
        {
            //nothing stored in instance to clear
            instance = null;
        }
    }
}
