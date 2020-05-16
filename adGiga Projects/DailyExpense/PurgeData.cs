using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataObjects;
using Business;
using System.Threading;

namespace ShopKeeper
{
    public partial class PurgeData : Form
    {
        public PurgeData()
        {
            InitializeComponent();
        }

        private void PurgeData_Load(object sender, EventArgs e)
        {
            statusLabel.Text = string.Empty;
            progressBar1.Visible = false;
            deleteDate.Value = DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0, 0));
            deleteDate.MaxDate = DateTime.Now;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete all data before " + deleteDate.Value.ToString("MMM/dd/yyyy")
                + "? Applicable to every customer", "adGiga:Database Purge",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                delete.Enabled = false;
                deleteDate.Enabled = false;
                cancel.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                backgroundWorker1.RunWorkerAsync(deleteDate.Value);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = PurgeAll((DateTime)e.Argument, (BackgroundWorker)sender, e);
        }

        private object PurgeAll(DateTime deleteDate, BackgroundWorker worker, DoWorkEventArgs e)
        {
            (new CommonManager()).BeginBatchOperation();
            TransactionManager tm = new TransactionManager();
            //get a list of all customers
            List<Customer> customers = (new CustomerManager()).GetAllCustomers();
            foreach (Customer customer in customers)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    worker.ReportProgress((int)((double)customers.IndexOf(customer) / (double)customers.Count * 100.0), "Deleting Sale/Purchase data of " + customer.Name);
                    tm.DeleteAllTransactionsBefore(customer.ID, deleteDate, true);
                }
            }
            //now delete expenses till the date..
            ExpenseManager em = new ExpenseManager();
            List<Expense> expenses = em.GetExpenses(new DateTime(1900, 1, 1), deleteDate);
            foreach (Expense expense in expenses)
            {
                em.DeleteExpenseById(expense.ID);
                worker.ReportProgress((int)((double)expenses.IndexOf(expense) / (double)expenses.Count * 100.0),"Deleting Expense Data of " + expense.TimeStamp.ToShortDateString());
            }
            (new CommonManager()).ConfirmBatchOperation();
            return null;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            statusLabel.Text = (string)e.UserState + "...";
            this.Refresh();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (statusLabel.Text == "xxx")
            {
                statusLabel.Text = "Action cancelled. All data reverted.";
            }
            else
            {
                statusLabel.Text = "All data before " + deleteDate.Value.ToString("MMM/yy/dddd") + " deleted.";
            }
            progressBar1.Visible = false;
            delete.Enabled = true;
            deleteDate.Enabled = true;
            cancel.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            statusLabel.Text = "xxx";
        }
    }
}
