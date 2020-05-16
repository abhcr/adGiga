using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataObjects;
using Business;

namespace ShopKeeper
{
    public partial class SalesHistory : Form
    {
        public SalesHistory()
        {
            InitializeComponent();
        }
        public void ShowHistory(int customerId, string customerName, DateTime referenceDate)
        {
            //Color rowColor = Color.SeaShell;
            this.Text = "Transaction History: " + customerName;
            this.customerId = customerId;
            //set start date of report - as 31 days behind by default
            startDate.Value = referenceDate.Subtract(new TimeSpan(31,0,0,0,0));
            PopulateValues();
            this.ShowDialog();
        }
        int customerId;
        private void PopulateValues()
        {
            saleGrid.Rows.Clear();
            DataGridViewRow row;
            double paymentAmount = 0.0;
            double subTotalForSale = 0.0; 
            List<Transaction> transactions = (new TransactionManager()).GetTransactionsByCustomerId(customerId);
            Customer customer = (new CustomerManager()).GetCustomerByID(customerId);
            //sort transactions in the order of increasing date
            transactions.Sort(delegate(Transaction a, Transaction b)
            {
                return a.TransactionTime.CompareTo(b.TransactionTime);
            });
            List<Transaction> transactionsToList = transactions.FindAll(delegate(Transaction a)
            {
                return a.TransactionTime.Date >= startDate.Value.Date;
            });
            //first add a row with balance brought forward till the selected date
            row = new DataGridViewRow();
            row.CreateCells(
                saleGrid,
                startDate.Value.ToString("dd/MM/yy"),
                string.Empty,
                "Old Balance:",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                (new CustomerManager()).GetPendingAmountTill(customerId, startDate.Value.Date));
            row.DefaultCellStyle.BackColor = Color.LightPink;
            saleGrid.Rows.Add(row);
            foreach (Transaction transaction in transactionsToList)
            {
                //construct information row:
                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    transaction.TransactionTime.ToString("dd/MM/yy hh:mmtt"),
                    string.Empty,
                    transaction.Remark,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty);
                row.DefaultCellStyle.BackColor = Color.Black;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.Tag = transaction.ID;
                saleGrid.Rows.Add(row);
                Payment p = (new PaymentManager()).GetPaymentByTransactionID(transaction.ID);
                if (p != null)
                {
                    paymentAmount = p.Amount;
                }
                else
                {
                    paymentAmount = 0.0;
                }
                subTotalForSale = 0.0;
                foreach (SalePurchase sale in (new SaleManager()).GetSalesByTransactionID(transaction.ID))
                {
                    //construct row for the sale
                    row = new DataGridViewRow();
                    row.CreateCells(saleGrid,
                        string.Empty, //sale.Transaction.TransactionTime.ToString("dd/MM/yy hh:mmtt"),
                        sale.Number,
                        sale.Item.Name,
                        sale.SaleRate.ToString("0.00"),
                        sale.Quantity.ToString("0.00"),
                        sale.Item.Unit.Name,
                        sale.SaleTotal.ToString("0.00"),
                        string.Empty);

                    if (transaction.IsPurchase)
                    {
                        row.HeaderCell.Value = "P";
                        row.HeaderCell.ToolTipText = "Purchased from " + customer.Name;
                    }
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Tag = transaction.ID;
                    saleGrid.Rows.Add(row);
                    subTotalForSale += sale.SaleTotal;
                }
                //add subtotal of this transaction below the sales
                if (subTotalForSale > 0)
                {
                    row = new DataGridViewRow();
                    row.CreateCells(saleGrid,
                        string.Empty,
                        string.Empty,
                        "Sub Total:",
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        subTotalForSale.ToString("0.00"));
                    row.DefaultCellStyle.BackColor = Color.LightCyan;
                    row.Tag = transaction.ID;
                    saleGrid.Rows.Add(row);
                }
                //add payment
                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    string.Empty,
                    string.Empty,
                    "Payment:",
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    paymentAmount.ToString("-0.00"));
                row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                row.Tag = transaction.ID;
                if (transaction.IsPurchase)
                {
                    row.HeaderCell.Value = "P";
                    row.HeaderCell.ToolTipText = "Payment Made to " + customer.Name;
                }
                saleGrid.Rows.Add(row);
            }
            pendingAmount.Text = (new CustomerManager()).GetPendingAmountTill(customerId, DateTime.Now.AddDays(1.0)).ToString("0.00");
            totalPurchase.Text = (new CustomerManager()).GetTotalPurchase(customerId, startDate.Value, true).ToString("0.00");
            totalSale.Text = (new CustomerManager()).GetTotalPurchase(customerId, startDate.Value, false).ToString("0.00");
            totalPaymtRcvd.Text = (new CustomerManager()).GetTotalPayment(customerId, startDate.Value, false).ToString("0.00");
            totalPaymtMade.Text = (new CustomerManager()).GetTotalPayment(customerId, startDate.Value, true).ToString("0.00");
            if (double.Parse(totalPurchase.Text) != 0.0)
            {
                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    string.Empty,
                    string.Empty,
                    "Total Purchase from " + customer.Name,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    totalPurchase.Text);
                saleGrid.Rows.Add(row);
            }
            if (double.Parse(totalPaymtMade.Text) != 0.0)
            {
                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    string.Empty,
                    string.Empty,
                    "Total Pymnt To " + customer.Name,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    totalPaymtMade.Text);
                saleGrid.Rows.Add(row);
            }
            if (double.Parse(totalSale.Text) != 0.0)
            {

                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    string.Empty,
                    string.Empty,
                    "Total Sale To " + customer.Name,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    totalSale.Text);
                saleGrid.Rows.Add(row);
            }

            if (double.Parse(totalPaymtRcvd.Text) != 0.0)
            {

                row = new DataGridViewRow();
                row.CreateCells(saleGrid,
                    string.Empty,
                    string.Empty,
                    "Total Payment from " + customer.Name,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    totalPaymtRcvd.Text);
                saleGrid.Rows.Add(row);
            }
                row = new DataGridViewRow();
            row.CreateCells(saleGrid,
                string.Empty,
                string.Empty,
                "Pending From " + customer.Name,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                pendingAmount.Text);
            saleGrid.Rows.Add(row);
            saleGrid.Refresh();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateValues();
        }

        private void saleGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (saleGrid.SelectedRows[0].Tag != null)
            {
                int transId = -1;
                if (int.TryParse(saleGrid.SelectedRows[0].Tag.ToString(), out transId))
                {
                    if (transId > -1)
                    {
                        EstimateForm editTransaction = new EstimateForm();
                        editTransaction.UpdateSale(transId);
                        PopulateValues();
                    }
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                try
                {
                    linesPrinted = 0;
                    printDocument.Print();
                }
                catch (Exception)
                {

                    MessageBox.Show("Please check if the printer or the connected computer is switched on and ready.",
                        "Cannot Print", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int linesPrinted = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int lineGap = 17;
            int x = e.PageBounds.Left;
            int y = e.PageBounds.Top;
            Font normalFont = new Font("Arial", 10.0f, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12.0f, FontStyle.Bold);
            Font underscoreFont = new Font("Arial", 10.0f, FontStyle.Underline);
            Brush brush = new SolidBrush(Color.Black);
            Font currentFont = normalFont;
            if (linesPrinted == 0)
            {
                e.Graphics.DrawString((new CustomerManager()).GetCustomerByID(customerId).Name, 
                    boldFont, brush, x, y);
                y += lineGap;
            }
            for (int i = linesPrinted; i < saleGrid.RowCount; i++)
            {
                if (saleGrid.Rows[i].DefaultCellStyle.BackColor == Color.Black)
                {
                    currentFont = boldFont;
                }
                else
                {
                    currentFont = normalFont;
                }
                for (int j = 0; j < saleGrid.ColumnCount; j++)
                {
                    
                    e.Graphics.DrawString(saleGrid[j, i].Value.ToString(),
                        boldFont, brush, x, y);
                    x += (int)((double)saleGrid.Columns[j].Width*1.25);
                }
                x = e.PageBounds.Left;
                y += lineGap;
                linesPrinted++;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete all records before " + startDate.Text + "?", "ShopKeeper-confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                if ((new TransactionManager()).DeleteAllTransactionsBefore(
                    this.customerId, startDate.Value, true))
                {
                    MessageBox.Show("Done! Outstanding amount is inserted as a new transaction.", "ShopKeeper-information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}