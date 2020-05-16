using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;

namespace ObjectCache
{
    public class ExpenseCache
    {
        object dummy = new object();
        private ExpenseCache()
        {
            lock (dummy)
            {
                ExpenseItem expenseItem;
                expenseItems = new List<ExpenseItem>();
                OleDbDataReader reader = DBFunctions.GetInstance().GetReader(
                    "Select ID, Item From ExpenseItems");
                while (reader.Read())
                {
                    expenseItem = new ExpenseItem();
                    expenseItem.ID = int.Parse(reader[0].ToString());
                    expenseItem.ItemName = reader[1].ToString();
                    expenseItems.Add(expenseItem);
                }
            }

        }
        private List<ExpenseItem> expenseItems;
        private static ExpenseCache instance;
        public static ExpenseCache GetInstance()
        {
            if (instance == null)
            {
                instance = new ExpenseCache();
            }
            return instance;
        }
        #region ExpenseItem
        public string[] GetExpenseItemNames()
        {
            List<string> namesList = new List<string>();
            foreach (ExpenseItem item in expenseItems)
            {
                namesList.Add(item.ItemName);
            }
            return namesList.ToArray();
        }

        public void InsertExpenseItem(string name)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Insert Into ExpenseItems (Item) Values(?)");
            command.Parameters.AddWithValue("Item", name);
            command.ExecuteNonQuery();
            command = DBFunctions.GetInstance().GetCommand(
                "Select ID From ExpenseItems Where Item=?");
            command.Parameters.AddWithValue("Item", name);
            ExpenseItem expenseItem = new ExpenseItem();
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                expenseItem.ID = int.Parse(reader[0].ToString());
            }
            expenseItem.ItemName = name;
            expenseItems.Add(expenseItem);
        }

        public ExpenseItem GetExpenseItemByName(string name)
        {
            return expenseItems.Find(delegate(ExpenseItem p) { return p.ItemName == name; });
        }

        public ExpenseItem GetExpenseItemById(int id)
        {
            return expenseItems.Find(delegate(ExpenseItem p) { return p.ID == id; });
        }
        #endregion


#region Expense
        


#endregion


        public void DeleteExpenseById(int id)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Delete From Expenses Where ID=?");
            command.Parameters.AddWithValue("ID", id);
            command.ExecuteNonQuery();
        }

        public void UpdateExpense(Expense updatedExpense)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Update Expenses Set Amount=?, ExpenseItem=?, Remark=?, LastUpdatedTime=?, Serial=? Where ID=?");
            command.Parameters.AddWithValue("Amount", updatedExpense.Amount);
            command.Parameters.AddWithValue("ExpenseItem", updatedExpense.ExpenseItem.ID);
            command.Parameters.AddWithValue("Remark", updatedExpense.Remark);
            command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = updatedExpense.TimeStamp;
            command.Parameters.AddWithValue("Serial", updatedExpense.Number);
            command.Parameters.AddWithValue("ID", updatedExpense.ID);
            command.ExecuteNonQuery();
        }

        public Expense InsertExpense(Expense newExpense)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Insert Into Expenses (Amount, ExpenseItem, Remark, Serial, LastUpdatedTime) Values(?, ?, ?, ?, ?)");
            command.Parameters.AddWithValue("Amount", newExpense.Amount);
            command.Parameters.AddWithValue("ExpenseItem", newExpense.ExpenseItem.ID);
            command.Parameters.AddWithValue("Remark", newExpense.Remark);
            command.Parameters.AddWithValue("Serial", newExpense.Number);
            command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = newExpense.TimeStamp;
            command.ExecuteNonQuery();

            command = DBFunctions.GetInstance().GetCommand(
                "Select ID From Expenses Where LastUpdatedTime=?");
            command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = newExpense.TimeStamp;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                newExpense.ID = int.Parse(reader[0].ToString());
            }
            return newExpense;
        }

        public List<Expense> GetExpenses(DateTime startDate, DateTime endDate)
        {
            Expense expense;
            List<Expense> expenses;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, Amount, ExpenseItem, Remark, LastUpdatedTime, Serial From Expenses Where LastUpdatedTime>=? And LastUpdatedTime<?");
            command.Parameters.Add("StartDate", OleDbType.Date).Value = startDate;
            command.Parameters.Add("EndDate", OleDbType.Date).Value = endDate;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            expenses = new List<Expense>();
            while (reader.Read())
            {
                expense = new Expense();
                expense.ID = int.Parse(reader[0].ToString());
                expense.Amount = double.Parse(reader[1].ToString());
                expense.Remark = reader[3].ToString();
                expense.TimeStamp = DateTime.Parse(reader[4].ToString());
                expense.Number = int.Parse(reader[5].ToString());
                expense.ExpenseItem = GetExpenseItemById(int.Parse(reader[2].ToString()));
                expenses.Add(expense);
            }
            return expenses;
        }

        public void Clear()
        {
            if (expenseItems != null)
            {
                expenseItems.Clear();
            }
            instance = null;
        }
    }
}
