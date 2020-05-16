using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using DataObjects;
using System.Net.Mail;

namespace ShopKeeper
{
    public partial class Main : Form
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        private EstimateForm estimateForm;
        public Main()
        {
            InitializeComponent();
            endDate.MaxDate = DateTime.Now;
            startDate.MaxDate = DateTime.Now;
            reportDate.MaxDate = DateTime.Now;
        }

        private void newSale_Click(object sender, EventArgs e)
        {
            estimateForm = new EstimateForm();
            estimateForm.CreateNewSale(date.Value);
            estimateForm.Dispose();
            RefreshAll();
        }

        private void RefreshAll()
        {
            this.Text = "Refreshing Cache..... Please Wait";
            RefreshCache();
            this.Text = "Refreshing Display..... Please Wait";
            RefreshSalesGrid();
            RefreshExpenseGrid();
            RefreshTitleValues();
            this.Text = "ShopKeeper";
            this.Refresh();
        }

        private void RefreshTitleValues()
        {
            CommonManager cm = new CommonManager();
            cashDisplay.Text = cm.GetCashInTray(date.Value).ToString();
            //totalSaleForDay.Text = cm.GetTotalSaleForDay(date.Value).ToString();
            //totalPaymentsForDay.Text = cm.GetTotalPaymentForDay(date.Value).ToString();
            //totalExpenseForDay.Text = cm.GetTotalExpenseForDay(date.Value).ToString();
            //creditDetail.Text = cm.GetTotalCreditForDay(date.Value).ToString();
            //if (double.Parse(creditDetail.Text) > 0 && double.Parse(totalPaymentsForDay.Text) != 0)
            //{
            //    creditDetail.Text += " (" + 
            //        (double.Parse(creditDetail.Text) / double.Parse(totalPaymentsForDay.Text) * 100.0).ToString("0.00") + 
            //        "%)";
            //}
            cm = null;
        }

        private void RefreshExpenseGrid()
        {
            DateTime today = date.Value;
            List<Expense> expenses = (new ExpenseManager()).GetExpenses(
                new DateTime(today.Year, today.Month, today.Day, 0, 0, 0),
                new DateTime(today.AddDays(1.0).Year, today.AddDays(1.0).Month, today.AddDays(1.0).Day, 0, 0, 0));
            expenseGrid.Rows.Clear();
            foreach (Expense exp in expenses)
            {
                expenseGrid.Rows.Add(
                    exp.Number,
                    exp.TimeStamp.ToString("hh:mm:ss tt"),
                    exp.ExpenseItem.ItemName,
                    exp.Amount,
                    exp.Remark,
                    exp.ID);
                expenseGrid[1, expenseGrid.Rows.Count - 2].Tag = exp.TimeStamp;//store full datetime
            }
            expenses.Clear();
            expenseGrid.Refresh();
        }
        private bool confirm = true;
        private void Main_Load(object sender, EventArgs e)
        {
            //startDate.Value = DateTime.Now;
            //endDate.Value = DateTime.Now;
            date.Value = DateTime.Now.Date;
            //
            if (!(new Welcome()).Verify())
            {
                //avoid confirmation when closing window
                confirm = false;
                this.Close();
            }
            else
            {
                secondTimer.Enabled = true;
                cacheRefreshTimer.Enabled = true;
                secondTimer_Tick(this, new EventArgs());
                StartNewDay();
                RefreshAll();
            }
        }
        private void StartNewDay()
        {
            CommonManager manager = new CommonManager();
            //First, check if the application starting for first time in the day.
            if (manager.CheckIfFirstTimeForDay(date.Value))
            {
                ////ask for the starting cash.
                //double startingCash = (new DayStartCash()).GetStartCash(DateTime.Parse(date.Text));
                double startingCash = 0;
                //mark day start in db
                manager.MarkDayStart(date.Value, startingCash);
            }
        }

        private void totalExpenseForDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainTab.SelectedTab = expenseTab;
        }

        private void totalSaleForDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainTab.SelectedTab = salesTab;
        }
        /// <summary>
        /// Load from database
        /// </summary>
        private void RefreshSalesGrid()
        {
            int rowCount = 0;
            int firstDisplayedScrollingRowIndex = -1;
            int selectedRowIndex = -1;
            if (saleSummaryGrid.RowCount > 0)
            {
                rowCount = saleSummaryGrid.RowCount;
                if (saleSummaryGrid.SelectedRows.Count > 0)
                {
                    selectedRowIndex = saleSummaryGrid.SelectedRows[0].Index;
                }
                firstDisplayedScrollingRowIndex = saleSummaryGrid.FirstDisplayedScrollingRowIndex;
            }

            CustomerManager cm = new CustomerManager();
            DateTime today = date.Value;
            DateTime tomorrow = date.Value.AddDays(1.0);
            List<SalesSummary> salesSummary = (new SaleManager()).GetSalesSummary(today.Date, tomorrow.Date);
            saleSummaryGrid.Rows.Clear();
            double pending;
            foreach (SalesSummary summaryRow in salesSummary)
            {
                if (summaryRow.CustomerName.Length == 0 || summaryRow.CustomerName == "cash")
                {
                    pending = 0;
                }
                else
                {
                    pending = cm.GetPendingAmountTill(summaryRow.Payment.Transaction.Customer.ID, DateTime.Now.AddDays(1.0));
                }
                saleSummaryGrid.Rows.Add(summaryRow.SaleNumber, summaryRow.SaleTime, summaryRow.CustomerName, summaryRow.SaleTotal,
                    summaryRow.PaymentTotal, pending,
                    summaryRow.Payment.Transaction.Remark);
            }
            salesSummary.Clear();
            cm = null; 
            saleSummaryGrid.Refresh();
            if (rowCount > 0)
            {
                saleSummaryGrid.ClearSelection();
                if (saleSummaryGrid.RowCount > rowCount)
                {
                    //if new row added... select it
                    saleSummaryGrid.FirstDisplayedScrollingRowIndex = rowCount;
                    saleSummaryGrid.Rows[rowCount].Selected = true;
                }
                else if (saleSummaryGrid.RowCount > selectedRowIndex && selectedRowIndex > -1)
                {
                    saleSummaryGrid.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    saleSummaryGrid.Rows[selectedRowIndex].Selected = true;
                }
                else if (saleSummaryGrid.RowCount <= selectedRowIndex && saleSummaryGrid.RowCount > 0)
                {
                    saleSummaryGrid.Rows[saleSummaryGrid.RowCount - 1].Selected = true;
                }
            }
        }

        private void expenseGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.CellStyle.BackColor == Color.Beige)//beige color for item column
            {
                TextBox expenseItem = (TextBox)e.Control;
                expenseItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                expenseItem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                expenseItem.AutoCompleteCustomSource.Clear();
                expenseItem.AutoCompleteCustomSource.AddRange((new ExpenseManager()).GetExpenseItemNames());
            }
            else
            {
                ((TextBox)e.Control).AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void expenseGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //if (expenseGrid[e.ColumnIndex, e.RowIndex].Value != null && e.ColumnIndex == 1)
            //{
            //    (new ExpenseManager()).InsertIfNewExpenseItem(expenseGrid[e.ColumnIndex, e.RowIndex].Value.ToString());

            //}
        }

        private void expenseGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (expenseGrid[0, e.RowIndex] != null)
            {
                if (expenseGrid[0, e.RowIndex].Value != null)
                {

                    //sync this expense into db
                    Expense expense = new Expense();
                    expense.Number = (int)expenseGrid[0, e.RowIndex].Value;
                    expense.TimeStamp = DateTime.Parse(expenseGrid[1, e.RowIndex].Tag.ToString());
                    expense.Amount = double.Parse(expenseGrid[3, e.RowIndex].Value.ToString());
                    if (expenseGrid[4, e.RowIndex].Value == null)
                    {
                        expense.Remark = string.Empty;
                    }
                    else
                    {
                        expense.Remark = expenseGrid[4, e.RowIndex].Value.ToString();
                    }
                    expense.ID = int.Parse(expenseGrid[5, e.RowIndex].Value.ToString());
                    expense.ExpenseItem = (new ExpenseManager()).SyncExpenseItem((string)expenseGrid[2, e.RowIndex].Value);
                    expense = (new ExpenseManager()).SyncExpense(expense);
                    expenseGrid[5, e.RowIndex].Value = expense.ID;
                }
            }
            RefreshTitleValues();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (confirm)
            {
                RefreshTitleValues();
                (new CommonManager()).CloseApplication(double.Parse(cashDisplay.Text), date.Text);
            }
        }
        private void secondTimer_Tick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                //date.Value = DateTime.Now.Date; << do not change date automatically. hence commented
            }
        }

        private void DayChangedRoutine()
        {
            //MessageBox.Show("Crossing the day", DateTime.Now.ToString("MMMM-dd-yyyy hh:mm:ss tt"), MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            if (secondTimer.Enabled)
            {
                RefreshAll();
            }
        }

        private void expenseGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //fill default values to new editing row
            expenseGrid[0, e.Row.Index - 1].Value = e.Row.Index;//serial number
            expenseGrid[1, e.Row.Index - 1].Value = DateTime.Now.ToString("hh:mm:ss tt");//time stamp for display
            expenseGrid[1, e.Row.Index - 1].Tag = DateTime.Parse(date.Text + " " + DateTime.Now.ToString("hh:mm:ss tt"));//full time stamp
            expenseGrid[5, e.Row.Index - 1].Value = -1; //dummy id
            expenseGrid[2, e.Row.Index - 1].Value = string.Empty;
            expenseGrid[3, e.Row.Index - 1].Value = "0";
            expenseGrid[4, e.Row.Index - 1].Value = string.Empty;
        }

        private void expenseGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            (new ExpenseManager()).DeleteExpenseById((int)e.Row.Cells[5].Value);
            RefreshTitleValues();
        }

        private void expenseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void expenseGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            object cellValue = e.FormattedValue;
            switch (e.ColumnIndex)
            {
                case 2:
                    //validate expense item name

                    break;
                case 3:
                    //validate expense amount
                    double doubleVar;
                    if (double.TryParse(cellValue.ToString(), out doubleVar) == false)
                    {
                        if (cellValue.ToString().Length > 0)
                        {
                            MessageBox.Show("Please enter a valid expense amount", "Wrong Entry", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            expenseGrid.RefreshEdit();
                            e.Cancel = true;
                        }
                    }
                    break;
                case 4:
                    //validate remarks

                    break;
                default:
                    break;
            }
        }

        private void expenseGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (expenseGrid[2, e.RowIndex].FormattedValue.ToString().Length > 0 
                && expenseGrid[3, e.RowIndex].FormattedValue.ToString().Length > 0)
            {
                //valid entry
            }
            else if (expenseGrid[2,e.RowIndex].FormattedValue.ToString().Length == 0 
                && expenseGrid[3,e.RowIndex].FormattedValue.ToString().Length ==0)
            {
                //TODO: clear blank rows from grid

            }
            else
            {
                MessageBox.Show("Please enter both expense item and expense amount", "Wrong Entry",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void saleSummaryGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (saleSummaryGrid.SelectedRows.Count == 1)
            {
                modify.Enabled = true;
            }
            else
            {
                modify.Enabled = false;
            }
        }

        private void modify_Click(object sender, EventArgs e)
        {
            estimateForm = new EstimateForm();
            estimateForm.UpdateSale(
                    int.Parse((saleSummaryGrid.SelectedRows[0].Cells[0].Value.ToString())));
            estimateForm.Dispose();
            RefreshAll();
           }

        private void button1_Click(object sender, EventArgs e)
        {
            estimateForm = new EstimateForm();
            estimateForm.GetPayment(DateTime.Parse(date.Text + " " + time.Text));
            estimateForm.Dispose();
            RefreshAll();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirm)
            {
                if (MessageBox.Show("Close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    //close
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void itemWiseSalesAnalysis_Click(object sender, EventArgs e)
        {
            //get the items sold today... and the quantity..
            Items itemListForm = new Items();
            Item selectedItem = new Item();
            selectedItem.Name = itemListForm.GetItemNameFromUser(startDate.Value, endDate.Value);
            reportText.Text = "Item\tRate\tQuantity\tTotal\tCustomer\tTime\tSaleUnit\n";
            reportText.Text += (new CommonManager()).GetSaleDetailsForItem(selectedItem, startDate.Value, endDate.Value);
            Clipboard.Clear();
            Clipboard.SetText(reportText.Text + " ", TextDataFormat.Text);
            MessageBox.Show("Copied to clipboard!", "ShopKeeper", MessageBoxButtons.OK, MessageBoxIcon.Information );
            reportText.SelectAll();
            reportText.Focus();
        }

        private void customerWiseSalesAnalysis_Click(object sender, EventArgs e)
        {
            //get the list of customers who bought items today.. and
        }

        private void eodCashFlow_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(DateTime.Now.ToString("MMMM-dd-yyyy hh:mm:ss tt"));
//            stringBuilder.AppendLine(reportDate.Value.ToString("dd/MM/yyyy"));
            stringBuilder.AppendLine("------------------------");
            stringBuilder.AppendLine("Columns:No.,Time,Customer,Total,Payed,Pending,Remark");
            stringBuilder.AppendLine("------------------------");
            //get all the sales with time...
            foreach (DataGridViewRow row in saleSummaryGrid.Rows)
            {
                stringBuilder.AppendLine(((int)(row.Index + 1)).ToString() + "\t" +
                    row.Cells[1].Value.ToString() + "\t" +
                    row.Cells[2].Value.ToString() + "\t" +
                    row.Cells[3].Value.ToString() + "\t" +
                    row.Cells[4].Value.ToString() + "\t" +
                    row.Cells[5].Value.ToString() + "\t" +
                    row.Cells[6].Value.ToString());
            }
            stringBuilder.AppendLine("------------------------------------------");
            stringBuilder.AppendLine("Total Collection:" + totalPaymentsForDay.Text);
            stringBuilder.AppendLine("------------------------------------------");
            stringBuilder.AppendLine("Expenses:");
            foreach (DataGridViewRow row in expenseGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    stringBuilder.AppendLine(row.Cells[0].Value.ToString() + "\t" +
                        row.Cells[1].Value.ToString() + "\t" +
                        row.Cells[2].Value.ToString() + "\t" +
                        row.Cells[3].Value.ToString() + "\t" +
                        row.Cells[4].Value.ToString());
                }
            }
            stringBuilder.AppendLine("------------------------------------------");
            stringBuilder.AppendLine("Total Expense:" + totalExpenseForDay.Text);
            stringBuilder.AppendLine("------------------------------------------");
            stringBuilder.AppendLine("End Of Day Balance: " + cashDisplay.Text);
            reportText.Text = stringBuilder.ToString();
            Clipboard.Clear();
            Clipboard.SetText(reportText.Text, TextDataFormat.Text);
            MessageBox.Show("Copied to clipboard!", "ShopKeeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reportText.SelectAll();
            reportText.Focus();
        }

        private void mailBackup_Click(object sender, EventArgs e)
        {
            //E-Mail Credentials and Sending
            SmtpClient theClient = new SmtpClient("mail.cdlam.co.in");
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential("mail@cdlam.co.in", "password-123");
            theClient.Credentials = theCredential;
            //theClient.Send((new CommonManager()).GetCompleteDBAsString()
            
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            if (endDate.Value < startDate.Value)
            {
                endDate.Value = startDate.Value;
            }
            endDate.MinDate = startDate.Value;
        }

        private void creditors_Click(object sender, EventArgs e)
        {
            //open customer selection dialog
            //int debtorId = (new Debtors()).ShowDebtorsAndGetId();
            Debtors d = new Debtors();
            d.ShowDebtorsAndGetId(startDate.Value);
            d.Dispose();
            //reportText.Text =
            //    (new CommonManager()).GetCreditReport(debtorId, startDate.Value, endDate.Value);
            //Clipboard.Clear();
            //Clipboard.SetText(reportText.Text, TextDataFormat.Text);
            //MessageBox.Show("Copied to clipboard!", "ShopKeeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //reportText.SelectAll();
            //reportText.Focus();
        }
        private void expenses_Click(object sender, EventArgs e)
        {
            string expenseName = (new Expenses()).GetExpenseItemFromUser(startDate.Value, endDate.Value);
            reportText.Text =
                (new CommonManager()).GetExpenseDetail(expenseName, startDate.Value, endDate.Value);
            Clipboard.Clear();
            Clipboard.SetText(reportText.Text + " ", TextDataFormat.Text);
            MessageBox.Show("Copied to clipboard!", "ShopKeeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reportText.SelectAll();
            reportText.Focus();
        }

        private void creditDetail_MouseHover(object sender, EventArgs e)
        {

        }

        private void creditDetail_MouseEnter(object sender, EventArgs e)
        {

        }

        private void creditDetail_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void totalSaleForDay_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainTab.SelectedTab = salesTab;
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            DayChangedRoutine();
        }

        private void cashbox_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void cashDisplay_Click(object sender, EventArgs e)
        {
            if (cashDisplay.Text == "Click")
            {
                RefreshTitleValues();
            }
            else
            {
                cashDisplay.Text = "Click";
            }
        }

        private void expenseGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cacheRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Text = "ShopKeeper...";
                RefreshCache();
                //RefreshAll();
                this.Text = "ShopKeeper";
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshCache()
        {
            (new CommonManager()).RefreshCache();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shopkeeper software.");
        }

        private void stockReport_Click(object sender, EventArgs e)
        {
            //get stock list and display...
            StringBuilder stockReport = new StringBuilder();
            stockReport.AppendLine(DateTime.Now.ToString());
            ItemManager im = new ItemManager();
            foreach (string itemName in im.GetNamesOfItems())
            {
                Item item = im.GetItemByName(itemName);
                stockReport.AppendLine(item.Name + "\t" + item.Stock.ToString());
            }
            reportText.Text = stockReport.ToString();
        }
    }
}