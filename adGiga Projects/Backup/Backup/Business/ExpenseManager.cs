using System;
using System.Collections.Generic;
using System.Text;
using ObjectCache;
using DataObjects;

namespace Business
{
    public class ExpenseManager
    {
        public List<Expense> GetExpenses(DateTime startDate, DateTime endDate)
        {
            //SalesDataSetTableAdapters.ExpensesTableAdapter expenseTableAdapter =
            //    new Business.SalesDataSetTableAdapters.ExpensesTableAdapter();
            //SalesDataSet.ExpensesDataTable expenseView = expenseTableAdapter.GetExpensesByTime(startDate, endDate);

            return ExpenseCache.GetInstance().GetExpenses(startDate, endDate);

        }

        public Expense SyncExpense(Expense expense)
        {
            //check if expense exists..
            if (expense.ID <0)
            {
                //have to insert it
                return ExpenseCache.GetInstance().InsertExpense(expense);
            }
            else
            {
                //have to update it
                ExpenseCache.GetInstance().UpdateExpense(expense);
                return expense;
            }
        }

        private Expense InsertNewExpense(Expense newExpense)
        {
            return ExpenseCache.GetInstance().InsertExpense(newExpense);
        }
        private void UpdateExpense(Expense updatedExpense)
        {
            ExpenseCache.GetInstance().UpdateExpense(updatedExpense);
        }

        public void DeleteExpenseById(int id)
        {
            ExpenseCache.GetInstance().DeleteExpenseById(id);
        }

        #region Expense Item

        public string[] GetExpenseItemNames()
        {
            return ExpenseCache.GetInstance().GetExpenseItemNames();
        }

        public ExpenseItem SyncExpenseItem(string name)
        {
            //check if item already exists in expense list, insert if new
            if (ExpenseCache.GetInstance().GetExpenseItemByName(name) == null)
            {
                ExpenseCache.GetInstance().InsertExpenseItem(name);
            }
            return ExpenseCache.GetInstance().GetExpenseItemByName(name);
        }
        public ExpenseItem GetExpenseItemByName(string itemName)
        {
            return ExpenseCache.GetInstance().GetExpenseItemByName(itemName);
        }
        #endregion



        internal double GetTotalExpenseForDay(DateTime day)
        {
            double expenseForDay = 0.0;
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0,0,0);
            DateTime end = new DateTime(day.AddDays(1.0).Year, day.AddDays(1.0).Month, day.AddDays(1.0).Day, 0, 0, 0);
            foreach (Expense exp in ExpenseCache.GetInstance().GetExpenses(start, end))
            {
                expenseForDay += exp.Amount;
            }
            return expenseForDay;
        }

        internal void RefreshCache()
        {
            ExpenseCache.GetInstance().Clear();
            ExpenseCache.GetInstance();
        }
    }
}
