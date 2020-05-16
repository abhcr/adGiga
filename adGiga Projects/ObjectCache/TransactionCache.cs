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
            //check if db is updated for sale and purchase
            if (!DBFunctions.GetInstance().CheckIfColumnExistsInTable("SaleOrPurchase", "Transactions"))
            {
                //db needs to be upgraded
                DBFunctions.GetInstance().OpenConnection();
                OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                    "ALTER TABLE Transactions ADD COLUMN SaleOrPurchase NUMBER");
                command.ExecuteNonQuery();
                //now default all non-set previous values to sale
                command = DBFunctions.GetInstance().GetCommand("Update Transactions " +
                    "Set SaleOrPurchase=?");
                command.Parameters.AddWithValue("SaleOrPurchase", 1);
                command.ExecuteNonQuery();
            }
            //check if db is updated for projects
            if (!DBFunctions.GetInstance().CheckIfColumnExistsInTable("Project", "Transactions"))
            {
                //get the id of default project
                int defaultProjectId = ProjectCache.GetInstance().GetProjectByName(string.Empty).ID;
                //db needs to be upgraded
                DBFunctions.GetInstance().OpenConnection();
                OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                    "ALTER TABLE Transactions ADD COLUMN Project NUMBER");
                command.ExecuteNonQuery();
                //now default set default project for everything.
                command = DBFunctions.GetInstance().GetCommand("Update Transactions " +
                    "Set Project=?");
                command.Parameters.AddWithValue("Project", defaultProjectId);
                command.ExecuteNonQuery();
            }
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
                    "(TransactionTime, Customer, Remarks, TransactionSum, LastUpdatedTime, SaleOrPurchase, Project) Values (?,?,?,?,?,?,?)");
                command.Parameters.Add("TransactionTime", OleDbType.Date).Value = transaction.TransactionTime;
                command.Parameters.AddWithValue("Customer", transaction.Customer.ID);
                command.Parameters.AddWithValue("Remarks", transaction.Remark);
                command.Parameters.AddWithValue("TransactionSum", transaction.TransactionSum);
                command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = updatedTime;
                command.Parameters.AddWithValue("SaleOrPurchase", transaction.IsPurchase ? 
                    Properties.Settings.Default.PurchaseVar : Properties.Settings.Default.SaleVar);
                if (transaction.ParentProject == null)
                {
                    command.Parameters.AddWithValue("Project", ProjectCache.GetInstance().GetProjectByName(string.Empty).ID);
                }
                else
                {
                    command.Parameters.AddWithValue("Project", transaction.ParentProject.ID);
                }
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
                    "Set Customer=?, Remarks=?, TransactionSum=?, LastUpdatedTime=Now(), TransactionTime=?, SaleOrPurchase=?, Project=? Where ID=?");
                command.Parameters.AddWithValue("Customer", transaction.Customer.ID);
                command.Parameters.AddWithValue("Remarks", transaction.Remark);
                command.Parameters.AddWithValue("TransactionSum", transaction.TransactionSum);
                command.Parameters.Add("TransactionTime", OleDbType.Date).Value =
                    transaction.TransactionTime;
                command.Parameters.AddWithValue("SaleOrPurchase", transaction.IsPurchase ? Properties.Settings.Default.PurchaseVar : Properties.Settings.Default.SaleVar);
                if (transaction.ParentProject == null)
                {
                    command.Parameters.AddWithValue("Project", ProjectCache.GetInstance().GetProjectByName(string.Empty).ID);
                }
                else
                {
                    command.Parameters.AddWithValue("Project", transaction.ParentProject.ID);
                }
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
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select TransactionTime, Customer, Remarks, TransactionSum, SaleOrPurchase, Project From Transactions " +
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
                if (int.TryParse(reader[4].ToString(), out intVar))
                {
                    tx.IsPurchase = (intVar == Properties.Settings.Default.PurchaseVar);
                }
                if (int.TryParse(reader[5].ToString(), out intVar))
                {
                    tx.ParentProject = new Project();
                    tx.ParentProject.ID = intVar;
                }

                tx.Customer = CustomerCache.GetInstance().GetCustomerById(tx.Customer.ID);
                tx.ParentProject = ProjectCache.GetInstance().GetProjectById(tx.ParentProject.ID);
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


        public double GetTransactionSumTotalByCustomerId(int customerID, DateTime startDate, bool purchase)
        {
            double sumTotal = 0;
            double doubleVar;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                //"Select Sum(T.TransactionSum) From Transactions As T Where T.Customer=?");
                "Select Sum(S.SaleQuantity*S.SaleRate) From Sales As S, Transactions As T " +
                "Where T.Customer=? And S.TransactionId=T.ID And T.TransactionTime>=? and T.SaleOrPurchase="
                + (purchase ? Properties.Settings.Default.PurchaseVar.ToString() : Properties.Settings.Default.SaleVar.ToString()));
            command.Parameters.AddWithValue("ID", customerID);
            command.Parameters.Add("TransactionTime", OleDbType.Date).Value = startDate.Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
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
                throw new ApplicationException("Error while deleting transaction. Tx ID:" + transactionId);
            }
        }

        public void Clear()
        {
            //nothing stored in instance to clear
            instance = null;
        }


        public List<Transaction> GetTransactionsByItem(int itemID)
        {
            DateTime timeVar;
            Transaction tx;
            List<Transaction> transactionsWithGivenItem = new List<Transaction>();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select S.TransactionId, T.TransactionTime, T.Customer, T.SaleOrPurchase, T.Remarks, T.Project " +
                "From Sales As S, Transactions As T Where S.Item=? And S.TransactionId=T.ID Order By T.TransactionTime");
            command.Parameters.AddWithValue("Item", itemID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                tx = new Transaction();
                tx.ID = int.Parse(reader[0].ToString());
                if (DateTime.TryParse(reader[1].ToString(), out timeVar))
                {
                    tx.TransactionTime = timeVar;
                }
                tx.Customer = new Customer();
                tx.Customer.ID = int.Parse(reader[2].ToString());
                tx.IsPurchase = (int.Parse(reader[3].ToString()) == 0);//0 if purchase
                tx.Remark = reader[4].ToString();
                tx.ParentProject.ID = int.Parse(reader[5].ToString());
                transactionsWithGivenItem.Add(tx);
            }
            return transactionsWithGivenItem;
        }

        public void ReplaceCustomer(int toBeReplacedID, int newID)
        {
            //update
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Transactions " +
                "Set Customer=? Where Customer=?");
            command.Parameters.AddWithValue("CustomerID", newID);
            command.Parameters.AddWithValue("OldID", toBeReplacedID);
            command.ExecuteNonQuery();
        }

        public List<Transaction> GetTransactionsByProjectId(int p)
        {
            List<Transaction> transactions = new List<Transaction>();
            DateTime timeVar;
            int intVar;
            double doubleVar;
            Transaction tx = new Transaction();
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select ID, TransactionTime, Customer, Remarks, TransactionSum, SaleOrPurchase, Project From Transactions " +
                "Where Project=?");
            command.Parameters.Clear();
            command.Parameters.AddWithValue("Project", p);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                tx = new Transaction();
                tx.ID = int.Parse(reader[0].ToString());
                if (DateTime.TryParse(reader[1].ToString(), out timeVar))
                {
                    tx.TransactionTime = timeVar;
                }
                if (int.TryParse(reader[2].ToString(), out intVar))
                {
                    tx.Customer = new Customer();
                    tx.Customer.ID = intVar;
                }
                tx.Remark = reader[3].ToString();

                if (double.TryParse(reader[4].ToString(), out doubleVar))
                {
                    tx.TransactionSum = doubleVar;
                }
                if (int.TryParse(reader[5].ToString(), out intVar))
                {
                    tx.IsPurchase = (intVar == Properties.Settings.Default.PurchaseVar);
                }
                if (int.TryParse(reader[6].ToString(), out intVar))
                {
                    tx.ParentProject = new Project();
                    tx.ParentProject.ID = intVar;
                }

                tx.Customer = CustomerCache.GetInstance().GetCustomerById(tx.Customer.ID);
                tx.ParentProject = ProjectCache.GetInstance().GetProjectById(tx.ParentProject.ID);
                transactions.Add(tx);
            }

            return transactions;
        }
    }
}
